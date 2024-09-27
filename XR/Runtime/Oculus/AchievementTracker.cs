using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFStudio.Common.Utils;
using Oculus.Platform;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.XR.Oculus
{
    public class AchievementTracker : MonoBehaviour
    {
        public List<AchievementTriggering> AchievementList;

        [Serializable]
        public class AchievementTriggering
        {
            public AchievementDescriptor Descriptor;
            
            public VoidEvent Trigger;
            public IntEvent TriggerInt;
            public GameObjectEvent TriggerGO;
            
            public void Register()
            {
                if (Trigger != null)
                    Trigger.Register(OnTrigger);
                else if (TriggerInt != null)
                    TriggerInt.Register(OnTrigger);
                else if (TriggerGO != null)
                    TriggerGO.Register(OnTrigger);
            }
            
            private void OnTrigger() => OnTrigger(1);

            private void OnTrigger(int count)
            {
                switch (Descriptor.Cached.Type)
                {
                    case AchievementType.Count:
                        Achievements.AddCount(Descriptor.ID, (ulong)count);
                        break;
                    case AchievementType.Simple:
                        Achievements.Unlock(Descriptor.ID);
                        break;
                    case AchievementType.Bitfield:
                        ApeLog.Warn("Bitfield achievements are not supported yet.");
                        break;
                    default:
                        ApeLog.Error("Unknown achievement type. Possibly due to not being initialised.");
                        break;
                }
            }
        }

        private IMetaAdapter _adapter;

        private void Awake()
        {
            _adapter = MetaAdapterFactory.Create();
        }

        public async Task Initialise()
        {
            AchievementList.ForEach(o => o.Register());

            var defs = await _adapter.GetAchievementDefs();
            
            foreach (var remote in defs)
            {
                var local = AchievementList.FirstOrDefault(o => o.Descriptor.ID == remote.Name);
                if (local == null)
                {
                    ApeLog.Error($"Achievement {remote.Name} does not exist locally.");
                    continue;
                }
                local.Descriptor.Cached.Type = remote.Type;
            }
        }
    }
}