using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class ComplexCurve : MonoBehaviour
    {
        public List<CurveData> Curves = new();
        public float DisplayPointRadius = 0.1f;
        public int DisplayHighlightIdx = 0;

        private Vector3 GetPointAtTime(float t, int curveIndex)
        {
            if (curveIndex < 0 || curveIndex >= Curves.Count)
            {
                return Vector3.zero;
            }

            var points = Curves[curveIndex];
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            Vector3 p = uuu * points.P0; // (1-t)^3 * P0
            p += 3 * uu * t * points.T0; // 3(1-t)^2 * t * P1
            p += 3 * u * tt * points.T1; // 3(1-t) * t^2 * P2
            p += ttt * points.P1; // t^3 * P3

            return p;
        }

        public Vector3 GetPointAtTime(float t)
        {
            var curveIndex = Mathf.FloorToInt(Curves.Count * t);
            t = Curves.Count * t - curveIndex;
            return GetPointAtTime(t, curveIndex);
        }

        [Button]
        public void AddCurveSection()
        {
            if (Curves.Count > 0)
            {
                var lastCurve = Curves[^1];
                Vector3 direction = (lastCurve.P1 - lastCurve.T1).normalized; // Determine the orientation of the last curve.

                Vector3 newP0 = lastCurve.P1; // Start at the end of the last curve.
                Vector3 newP1 = newP0 + direction; // Place P1 along the same direction.
                Vector3 newP2 = newP1 + direction; // Place P2 further along the same direction.
                Vector3 newP3 = newP2 + direction; // Place P3 even further.

                CurveData newCurveData = new CurveData
                {
                    P0 = newP0,
                    T0 = newP1,
                    T1 = newP2,
                    P1 = newP3,
                };

                Curves.Add(newCurveData);
            }
            else
            {
                Curves.Add(new CurveData()); // If it's the first curve, just add a default curve.
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (Curves.Count < 1) return;

            for (var i = 0; i < Curves.Count; i++)
            {
                var data = Curves[i];
                // Use GetPointAtTime to draw the curve.
                Gizmos.color = Color.white;
                Vector3 lastPoint = transform.TransformPoint(data.P0);
                for (float t = 0.1f; t < 1; t += 0.1f)
                {
                    Vector3 nextPoint = transform.TransformPoint(GetPointAtTime(t, Curves.IndexOf(data)));
                    Gizmos.DrawLine(lastPoint, nextPoint);
                    lastPoint = nextPoint;
                }

                Gizmos.DrawLine(lastPoint, transform.TransformPoint(data.P1));
                Gizmos.color = (i == DisplayHighlightIdx) ? Color.green : Color.yellow;
                Gizmos.DrawSphere(transform.TransformPoint(data.T0), DisplayPointRadius);
                Gizmos.color = (i == DisplayHighlightIdx) ? Color.red : Color.gray;
                Gizmos.DrawSphere(transform.TransformPoint(data.T1), DisplayPointRadius);
            }
        }

        [Serializable]
        public class CurveData
        {
            public Vector3 P0 = Vector3.zero;
            public Vector3 P1 = new Vector3(3, 3, 0);
            public Vector3 T0 = new Vector3(1, 1, 0);
            public Vector3 T1 = new Vector3(2, 2, 0);
        }
    }
}