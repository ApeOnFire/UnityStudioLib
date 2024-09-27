using UnityAtoms;
using UnityAtoms.MonoHooks;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    /// <summary>
    /// Mono Hook for [`OnTriggerEnter`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html), [`OnTriggerExit`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerExit.html) and [`OnTriggerStay`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerStay.html)
    /// Added filtering by tag.
    /// </summary>
    [EditorIcon("atom-icon-delicate")]
    [AddComponentMenu("Unity Atoms/Hooks/On Trigger Hook Tagged")]
    public sealed class OnTriggerHookTagged : ColliderHook
    {
        [Tooltip("The triggering collider must have this tag.")]
        public string CollideTag;
        /// <summary>
        /// Set to true if Event should be triggered on `OnTriggerEnter`
        /// </summary>
        [SerializeField]
        private bool _triggerOnEnter = default(bool);
        /// <summary>
        /// Set to true if Event should be triggered on `OnTriggerExit`
        /// </summary>
        [SerializeField]
        private bool _triggerOnExit = default(bool);
        /// <summary>
        /// Set to true if Event should be triggered on `OnTriggerStay`
        /// </summary>
        [SerializeField]
        private bool _triggerOnStay = default(bool);

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
            if (_triggerOnEnter && (string.IsNullOrEmpty(CollideTag) || other.CompareTag(CollideTag)))
            {
                Debug.Log("OnTriggerEnter - Triggered");
                OnHook(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_triggerOnExit && (string.IsNullOrEmpty(CollideTag) || other.CompareTag(CollideTag))) OnHook(other);
        }

        private void OnTriggerStay(Collider other)
        {
            if (_triggerOnStay && (string.IsNullOrEmpty(CollideTag) || other.CompareTag(CollideTag))) OnHook(other);
        }
    }
}
