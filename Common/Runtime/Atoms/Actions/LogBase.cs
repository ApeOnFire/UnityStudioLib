using AFStudio.Common.Utils;
using UnityAtoms;
using LogType = UnityEngine.LogType;

namespace AFStudio.Common.Atoms.Actions
{
    public class LogBase<T> : AtomAction<T>
    {
        public bool LogToVR = true;
        public LogType LogType = LogType.Log;

        protected void LogMessage(string message)
        {
            switch (LogType)
            {
                case LogType.Warning:
                    ApeLog.Warn(message, LogToVR);
                    break;
                case LogType.Error:
                    ApeLog.Error(message, LogToVR);
                    break;
                case LogType.Exception:
                    ApeLog.Error($"Exception: {message}", LogToVR);
                    break;
                default:
                    ApeLog.Log(message, LogToVR);
                    break;
            }
            
        }
    }
}