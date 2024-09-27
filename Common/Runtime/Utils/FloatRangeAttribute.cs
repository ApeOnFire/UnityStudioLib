using UnityEngine;

namespace AFStudio.Common.Utils
{
    public class FloatRangeAttribute : PropertyAttribute
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        public FloatRangeAttribute(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}