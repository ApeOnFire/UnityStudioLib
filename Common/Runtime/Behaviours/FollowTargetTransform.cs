using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class FollowTargetTransform : MonoBehaviour
    {
        [InfoBox("Causes the object to stick to the target transform without having to be reparented.")]
        public Transform Target;
        public bool FollowPosition = true;
        public bool FollowRotation = true;
        public bool KeepPositionOffset;
        public bool KeepRotationOffset;
        
        private Vector3 _positionOffset = Vector3.zero;
        private Quaternion _rotationOffset = Quaternion.identity;

        private void Start()
        {
            if (!Target) enabled = false;
            if (KeepPositionOffset) _positionOffset = transform.position - Target.position;
            if (KeepRotationOffset) _rotationOffset = Quaternion.Inverse(Target.rotation) * transform.rotation;
        }

        private void LateUpdate()
        {
            if (FollowPosition) transform.position = Target.position + _positionOffset;
            if (FollowRotation) transform.rotation = Target.rotation * _rotationOffset;
        }
    }
}