using UnityEngine;

namespace AFStudio.Common.Utils
{
    public static class EngineExtensions
    {
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 ToVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }

        public static Vector3 ToVector3(this Vector2 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        public static Vector3 ToFlippedX(this Vector3 vector)
        {
            return new Vector3 { x = -vector.x, y = vector.y, z = vector.z };
        }

        public static Vector2 AddToAll(this Vector2 vector, float toAdd)
        {
            return new Vector2(vector.x + toAdd, vector.y + toAdd);
        }
        
        public static Vector2 Rotate(this Vector2 vector, float degrees)
        {
            var radians = degrees * Mathf.Deg2Rad;
            var sin = Mathf.Sin(radians);
            var cos = Mathf.Cos(radians);
            return new Vector2(vector.x * cos - vector.y * sin, vector.x * sin + vector.y * cos);
        }
        
        public static Vector3 Rotate(this Vector3 vector, float degrees)
        {
            var radians = degrees * Mathf.Deg2Rad;
            var sin = Mathf.Sin(radians);
            var cos = Mathf.Cos(radians);
            return new Vector3(vector.x * cos - vector.y * sin, vector.x * sin + vector.y * cos, vector.z);
        }
        
        public static Vector2 Rotate(this Vector2 vector, Vector2 sinCos)
        {
            return new Vector2(vector.x * sinCos.y - vector.y * sinCos.x, vector.x * sinCos.x + vector.y * sinCos.y);
        }
        
        public static Vector3 Rotate(this Vector3 vector, Vector2 sinCos)
        {
            return new Vector3(vector.x * sinCos.y - vector.y * sinCos.x, vector.x * sinCos.x + vector.y * sinCos.y, vector.z);
        }
        
        /// <summary>
        /// Returns a random float between x and y
        /// </summary>
        public static float Random(this Vector2 vector)
        {
            return UnityEngine.Random.Range(vector.x, vector.y);
        }
        
        public static int RandomInt(this Vector2 vector)
        {
            return UnityEngine.Random.Range(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
        }
        
        public static Vector2 RandomRange(this Vector2 vector)
        {
            return new Vector2(UnityEngine.Random.Range(vector.x, vector.y), UnityEngine.Random.Range(vector.x, vector.y));
        }
        
        public static Vector3 CubicEaseInOut(this Vector3 b, Vector3 c, float t)
        {
            t = Mathf.Clamp01(t);
            t *= 2;
            if (t < 1) return (c - b) / 2 * (t * t * t) + b;
            t -= 2;
            return (c - b) / 2 * (t * t * t + 2) + b;
        }
    }
}
