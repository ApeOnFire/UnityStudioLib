using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Actions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Logging/LogIntPair")]
    public class LogIntPair : LogBase<IntPair>
    {
        public string FormatString = "Int1: {0}, Int2: {1}";
        
        public override void Do(IntPair value)
        {
            LogMessage(string.Format(FormatString, value.Item1, value.Item2));
        }
    }
}