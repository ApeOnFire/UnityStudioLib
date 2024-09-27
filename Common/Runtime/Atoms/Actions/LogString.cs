using UnityEngine;

namespace AFStudio.Common.Atoms.Actions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Logging/LogString")]
    public class LogString : LogBase<string>
    {
        public string FormatString = "String: {0}";
        
        public override void Do(string value)
        {
            LogMessage(string.Format(FormatString, value));
        }
    }
}