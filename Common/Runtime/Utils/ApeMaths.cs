using UnityEngine;

namespace AFStudio.Common.Utils
{
    public static class ApeMaths
    {
        public static Vector3 CubicEaseInOut(Vector3 b, Vector3 c, float t)
        {
            t = Mathf.Clamp01(t);
            if (t < 0.5f) return 4 * (c - b) * t * t * t + b;
            t -= 1;
            return 0.5f * (c - b) * (t * t * t + 2) + b;
        }

        public static float CubicEaseInOut(float b, float c, float t)
        {
            t = Mathf.Clamp01(t);
            t *= 2;
            if (t < 1) return (c - b) / 2 * (t * t * t) + b;
            t -= 2;
            return (c - b) / 2 * (t * t * t + 2) + b;
        }
    }
}