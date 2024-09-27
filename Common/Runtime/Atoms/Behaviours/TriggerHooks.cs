using System;
using AFStudio.Common.Utils;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace AFStudio.Common.Atoms.Behaviours
{
    [Serializable] public class TriggerHookEvent : UnityEvent<GameObject> { }
    
    [RequireComponent(typeof(Collider))]
    public class TriggerHooks : MonoBehaviour
    {
        [Title("Config")]
        [Tooltip("The triggering collider must have this tag.")]
        [Tag]
        public string CollideTag;
        public bool FireOnEnter;
        public bool FireOnExit;
        public bool LogToConsole;
        [Title("Output")]
        public GameObjectEvent AtomEvent;
        public VoidEvent VoidAtomEvent;
        public TriggerHookEvent UnityEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (FireOnEnter) ConsiderFireNow(other.gameObject);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (FireOnExit) ConsiderFireNow(other.gameObject);
        }

        [FoldoutGroup("Debug"), Button, DisableInEditorMode]
        private void ConsiderFireNow(GameObject byOther, bool force = false)
        {
            if (!force && !string.IsNullOrEmpty(CollideTag) && !byOther.CompareTag(CollideTag)) return;
            
            if (LogToConsole) ApeLog.Log($"{name} triggered by {byOther.name} (tag: {byOther.tag}).");
            UnityEvent?.Invoke(byOther);
            if (AtomEvent) AtomEvent.Raise(byOther);
            if (VoidAtomEvent) VoidAtomEvent.Raise();
        }
    }
}
