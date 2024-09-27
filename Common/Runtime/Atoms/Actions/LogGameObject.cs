using UnityEngine;

namespace AFStudio.Common.Atoms.Actions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Logging/LogGameObject")]
    public class LogGameObject : LogBase<GameObject>
    {
        public string FormatString = "GameObject: {0}";
        
        public override void Do(GameObject value)
        {
            LogMessage(string.Format(FormatString, value != null ? value.name : "null"));
        }
    }
}