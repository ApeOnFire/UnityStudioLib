using System.Collections.Generic;
using UnityEngine;

namespace AFStudio.XR.Oculus
{
    [CreateAssetMenu(menuName = "Platform/AchievementsData")]
    public class AchievementsData : ScriptableObject
    {
        public List<AchievementDescriptor> Achievements;
    }
}