using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    [RequireComponent(typeof(LineRenderer))]
    public class HangingRopeLineRenderer : MonoBehaviour
    {
        public Transform StartPoint;
        public Transform EndPoint;
        public int VertexCount = 10;
        public float Width = 0.1f;
        public AnimationCurve GravityEffect;

        private LineRenderer lineRenderer;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = VertexCount;
            lineRenderer.startWidth = Width;
            lineRenderer.endWidth = Width;
            lineRenderer.useWorldSpace = true;
        }

        void Update()
        {
            if (StartPoint == null || EndPoint == null)
            {
                return;
            }

            var startPoint = StartPoint.position;
            var endPoint = EndPoint.position;

            var direction = endPoint - startPoint;
            var step = direction / VertexCount;

            // Use the GravityEffect curve to simulate the rope hanging effect
            for (var i = 0; i < VertexCount; i++)
            {
                var t = i / (float)VertexCount;
                var offset = Vector3.down * GravityEffect.Evaluate(t);
                lineRenderer.SetPosition(i, startPoint + step * i + offset);
            }
        }
    }
}
