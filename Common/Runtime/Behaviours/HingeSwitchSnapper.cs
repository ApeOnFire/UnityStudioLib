using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class HingeSwitchSnapper : MonoBehaviour
    {
        public HingeJoint Hinge;

        public void SnapToUp()
        {
            // Activate the spring on the hinge to snap it to the upper limit
            var spring = Hinge.spring;
            spring.targetPosition = Hinge.limits.max;
            Hinge.spring = spring;
        }
        
        public void SnapToDown()
        {
            // Activate the spring on the hinge to snap it to the lower limit
            var spring = Hinge.spring;
            spring.targetPosition = Hinge.limits.min;
            Hinge.spring = spring;
        }

        private void Reset()
        {
            Hinge = GetComponent<HingeJoint>();
        }
    }
}