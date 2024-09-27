using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class RotateOverTime : MonoBehaviour
    {
        public bool RandomDirection;
        [ShowIf("@RandomDirection")]
        [MinMaxSlider(0, 500)] public Vector2 RandomSpeedRange;
        [ShowIf("@!RandomDirection")]
        public Vector3 AngularVelocity;
        [ShowIf("@!RandomDirection")]
        public Space RelativeTo = Space.Self;
        
        private void Start()
        {
            if (RandomDirection)
            {
                AngularVelocity = new Vector3(Random.Range(RandomSpeedRange.x, RandomSpeedRange.y),
                    Random.Range(RandomSpeedRange.x, RandomSpeedRange.y),
                    Random.Range(RandomSpeedRange.x, RandomSpeedRange.y));
            }
        }
        
        protected void Update()
        {
            transform.Rotate(AngularVelocity * Time.deltaTime, RelativeTo);
        }
    }
}