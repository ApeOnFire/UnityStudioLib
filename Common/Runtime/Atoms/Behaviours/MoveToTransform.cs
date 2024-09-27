using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class MoveToTransform : MonoBehaviour
    {
        public Transform Target;
        public float MoveDuration = 1f;
        public bool ReparentOnMove = true;
        public bool IsKinematicOnMove = true;
        
        [Button, DisableInEditorMode]
        public void MoveNow()
        {
            if (!Target)
            {
                Debug.LogWarning("Target is null, cannot move.");
                return;
            }

            if (ReparentOnMove) transform.SetParent(Target);
            if (IsKinematicOnMove) GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(DoMove());
        }
        
        private IEnumerator DoMove()
        {
            var t = 0f;
            while (t <= MoveDuration)
            {
                t += Time.deltaTime;
                // Move towards the target over MoveDuration seconds.
                transform.position = Vector3.Lerp(transform.position, Target.position, t);
                // Rotate towards the target over MoveDuration seconds.
                transform.rotation = Quaternion.Slerp(transform.rotation, Target.rotation, t);
                yield return null;
            }
            // Ensure the final position is exactly the target position.
            transform.position = Target.position;
            transform.rotation = Target.rotation;
        }
    }
}