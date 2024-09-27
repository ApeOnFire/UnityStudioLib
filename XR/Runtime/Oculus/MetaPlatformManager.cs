using AFStudio.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.XR.Oculus
{
    public class MetaPlatformManager : MonoBehaviour
    {
        public bool LogInOnAwake;
        public AchievementTracker AchievementTracker;
        
        // Application-scoped Oculus ID
        [SerializeField] [ReadOnly] private ulong _oculusID;
        // Oculus username
        [SerializeField] [ReadOnly] private string _oculusName;


        public IMetaAdapter Meta => _adapter;
        private IMetaAdapter _adapter;
        
        private async void Awake()
        {
            // Don't destroy this object on scene change
            DontDestroyOnLoad(gameObject);
            
            _adapter = MetaAdapterFactory.Create();
            
            if (!await _adapter.PerformEntitlementCheck()) return;
            
            if (LogInOnAwake)
            {
                var user = await _adapter.PerformLogin();
                if (user != null)
                {
                    _oculusID = user.ID;
                    _oculusName = user.OculusID;
                    ApeLog.Log($"Logged in. ID: {_oculusID}, Name: {_oculusName}");
                }
            }
            if (AchievementTracker != null) await AchievementTracker.Initialise();
        }
    }
}