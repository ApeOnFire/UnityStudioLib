using System;
using UnityEngine;

namespace AFStudio.Common.Utils
{
    public static class ApeLog
    {
        public static void Log(string message, bool logToVR = true)
        {
            // if (logToVR) VRUtils.Instance.Log(message);
            // else 
            Debug.Log(message);
        }
        
        public static void Warn(string message, bool logToVR = true)
        {
            // if (logToVR) VRUtils.Instance.Warn(message);
            // else 
            Debug.LogWarning(message);
        }
        
        public static void Error(string message, bool logToVR = true)
        {
            // if (logToVR) VRUtils.Instance.Error(message);
            Debug.LogError(message);
        }
        
        public static void Assert(string message, bool logToVR = true)
        {
            // if (logToVR) VRUtils.Instance.Log(message);
            Debug.LogAssertion(message);
        }

        public static void Exception(Exception exception, bool logToVR = true)
        {
            // if (logToVR) VRUtils.Instance.Error(exception.Message);
            Debug.LogException(exception);
        }
    }
}