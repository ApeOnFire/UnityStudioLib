using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class LerpScale : MonoBehaviour
    {
        public GameObject Subject;
        public float ScaleMultiplier = 10.0f;
        public float Duration = 0.1f;

        [Button]
        public void LerpScaleNow()
        {
            StartCoroutine(DetonateCoroutine());
        }
        
        private IEnumerator DetonateCoroutine()
        {
            var startScale = Subject.transform.localScale;
            var endScale = startScale * ScaleMultiplier;
            var startTime = Time.time;
            var endTime = startTime + Duration;
            while (Time.time < endTime)
            {
                var t = (Time.time - startTime) / Duration;
                Subject.transform.localScale = Vector3.Lerp(startScale, endScale, t);
                yield return null;
            }
            Subject.transform.localScale = endScale;
        }
        
        private void Reset()
        {
            Subject = gameObject;
        }
    }
}