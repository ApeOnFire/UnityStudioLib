using System;
using Oculus.Platform;
using UnityEngine;

namespace AFStudio.XR.Oculus
{
    [CreateAssetMenu(menuName = "Platform/Achievement")]
    public class AchievementDescriptor : ScriptableObject
    {
        public string ID;
        public string Title;

        public Cache Cached;
        
        [Serializable]
        public class Cache
        {
            public AchievementType Type;
        }
    }
}