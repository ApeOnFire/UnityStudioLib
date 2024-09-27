using AFStudio.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class DestroySubject : MonoBehaviour
    {
        public GameObject Subject;
        [Tooltip("Destroy the subject when this component is enabled.")]
        public bool WhenEnabled;
        [Tooltip("Only used if the delay param of DestroyNow() is negative.")]
        public float Delay;
        public bool LogOnDestroy = true;

        private void OnEnable()
        {
            if (WhenEnabled) DestroyNow(Delay);
        }
        
        [FoldoutGroup("Debug")]
        [Button]
        public void DestroyNow(float delay = -1f)
        {
            if (delay < 0f) delay = Delay;
            if (LogOnDestroy) ApeLog.Log($"Destroying {Subject.name} in {delay} seconds.");
            Destroy(Subject, delay);
        }

        private void Reset()
        {
            Subject = gameObject;
        }
    }
}