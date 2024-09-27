using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

namespace AFStudio.XR
{
    /// <summary>
    /// Prevents the error: "XR Management has already initialized an active loader in this scene"
    /// See: https://communityforums.atmeta.com/t5/Unity-VR-Development/Meta-XR-Simulator-starts-only-once/m-p/1142983#M23492
    /// </summary>
    public class VRInit : MonoBehaviour
    {

#if UNITY_EDITOR
        public bool EnableXRAtStart = true;

        private void Start()
        {
            if (EnableXRAtStart) EnableXR();
        }

        private void OnDestroy()
        {
            DisableXR();
        }

        public void EnableXR()
        {
            StartCoroutine(StartXRCoroutine());
        }

        public void DisableXR()
        {
            XRGeneralSettings.Instance?.Manager?.StopSubsystems();
            XRGeneralSettings.Instance?.Manager?.DeinitializeLoader();
        }

        public IEnumerator StartXRCoroutine()
        {
            if (XRGeneralSettings.Instance == null)
            {
                XRGeneralSettings.Instance = XRGeneralSettings.CreateInstance<XRGeneralSettings>();
            }

            if (XRGeneralSettings.Instance.Manager == null)
            {
                yield return new WaitUntil(() => XRGeneralSettings.Instance.Manager != null);
            }

            XRGeneralSettings.Instance?.Manager?.InitializeLoaderSync();

            if (XRGeneralSettings.Instance?.Manager?.activeLoader == null)
            {
                Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
            }
            else
            {
                XRGeneralSettings.Instance?.Manager?.StartSubsystems();
            }
        }

#endif

    }
}