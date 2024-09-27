using AFStudio.Common.Utils;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class PointToMainCamera : MonoBehaviour
    {
        public float MinDistance = 5;
        
        private Camera _mainCamera;
        private bool _isTooClose;
        
        private void OnEnable()
        {
            _mainCamera = Camera.main;
            
            if (!_mainCamera)
            {
                ApeLog.Warn($"PointToMainCamera ({name}): No main camera found");
                return;
            }
            this.RepeatAction(0.25f, () =>
            {
                _isTooClose = Vector3.Distance(transform.position, _mainCamera.transform.position) < MinDistance;
            });
            this.RepeatAction(() =>
            {
                if (!_isTooClose) transform.LookAt(_mainCamera.transform);
            });
        }
    }
}