using AFStudio.Common.Utils;
using UnityAtoms;
using UnityEngine;
using LogType = UnityEngine.LogType;

namespace AFStudio.Common.Atoms.Actions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Logging/LogStaticMessage")]
    public class LogStaticMessage : AtomAction
    {
        public string Message = "Test debug message";
        public bool LogToVR = true;
        public LogType LogType = LogType.Log;

        public override void Do()
        {
            // switch LogType
            switch (LogType)
            {
                case LogType.Warning:
                    ApeLog.Warn(Message, LogToVR);
                    break;
                case LogType.Error:
                    ApeLog.Error(Message, LogToVR);
                    break;
                case LogType.Exception:
                    ApeLog.Error($"Exception: {Message}", LogToVR);
                    break;
                default:
                    ApeLog.Log(Message, LogToVR);
                    break;
            }
            
        }
    }
}