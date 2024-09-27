using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace AFStudio.Common.Behaviours
{
    [Serializable] public class CollisionEvent : UnityEvent<Collision> { }
    
    public class SendCollisionEvents : MonoBehaviour
    {
        [Tooltip("The triggering collider must have this tag.")]
        public string CollideTag;
        public CollisionEvent CollisionEnter;
        
        [Button]
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"Hit {other.gameObject.name} with tag {other.gameObject.tag}.");
            if (string.IsNullOrEmpty(CollideTag) || other.gameObject.CompareTag(CollideTag))
            {
                CollisionEnter.Invoke(other);
            }
        }
    }
}