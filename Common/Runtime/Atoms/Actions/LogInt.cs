using UnityEngine;

namespace AFStudio.Common.Atoms.Actions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Logging/LogInt")]
    public class LogInt : LogBase<int>
    {
        public string FormatString = "Int: {0}";
        
        public override void Do(int value)
        {
            LogMessage(string.Format(FormatString, value));
        }
    }
}