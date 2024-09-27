#if UNITY_EDITOR
using AFStudio.Common.Behaviours;
using UnityEditor;
using UnityEngine;

namespace AFStudio.Common.Editor
{
    // [CustomEditor(typeof(ComplexCurve))]
    public class CurveComponentEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            ComplexCurve curve = (ComplexCurve)target;

            if (curve == null || curve.Curves.Count < 1) return;

            foreach (var points in curve.Curves)
            {
                Handles.DrawBezier(
                    points.P0, 
                    points.P1, 
                    points.T0, 
                    points.T1, 
                    Color.white, null, 2f);

                points.P0 = Handles.PositionHandle(points.P0, Quaternion.identity);
                points.T0 = Handles.PositionHandle(points.T0, Quaternion.identity);
                points.T1 = Handles.PositionHandle(points.T1, Quaternion.identity);
                points.P1 = Handles.PositionHandle(points.P1, Quaternion.identity);
            }
        }
    }
}
#endif