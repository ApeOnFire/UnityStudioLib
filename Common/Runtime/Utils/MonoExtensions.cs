using System;
using System.Collections;
using UnityEngine;

namespace AFStudio.Common.Utils
{
    public static class MonoExtensions
    {
        public static Coroutine ScheduleAction(this MonoBehaviour mono, float delay, Action action)
        {
            return mono.StartCoroutine(DelayedAction(mono, delay, action));
        }
        
        public static Coroutine ScheduleFrameAction(this MonoBehaviour mono, int frameDelay, Action action)
        {
            return mono.StartCoroutine(DelayedFrameAction(mono, frameDelay, action));
        }
        
        public static Coroutine RepeatAction(this MonoBehaviour mono, Action action, int loops = Int32.MaxValue)
        {
            return mono.StartCoroutine(RepeatedFrameAction(mono, action, loops));
        }
        
        public static Coroutine RepeatAction(this MonoBehaviour mono, float repDelay, Action action, int loops = Int32.MaxValue)
        {
            return mono.StartCoroutine(RepeatedAction(mono, repDelay, action, loops));
        }
        
        public static Coroutine RepeatAction(this MonoBehaviour mono, float repDelay1, Action action1, float repDelay2, Action action2, int loops = Int32.MaxValue)
        {
            return mono.StartCoroutine(RepeatedDoubleAction(mono, repDelay1, action1, repDelay2, action2, loops));
        }
        
        public static Coroutine RepeatUntilFalse(this MonoBehaviour mono, float repDelay, Func<bool> action, int loops = Int32.MaxValue)
        {
            return mono.StartCoroutine(RepeatedUntilFalse(mono, repDelay, action, loops));
        }
        
        public static Coroutine ScheduleEndOfFrame(this MonoBehaviour mono, Action action)
        {
            return mono.StartCoroutine(EndOfFrameAction(mono, action));
        }
        
        private static IEnumerator DelayedAction(this MonoBehaviour mono, float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action();
        }
        
        private static IEnumerator RepeatedAction(this MonoBehaviour mono, float repDelay, Action action, int loops)
        {
            for (int i = 0; i < loops; i++)
            {
                yield return new WaitForSeconds(repDelay);
                action();
            }
        }
        
        private static IEnumerator RepeatedUntilFalse(this MonoBehaviour mono, float repDelay, Func<bool> action, int loops)
        {
            for (int i = 0; i < loops; i++)
            {
                yield return new WaitForSeconds(repDelay);
                if (!action()) break;
            }
        }
        
        private static IEnumerator RepeatedFrameAction(this MonoBehaviour mono, Action action, int loops)
        {
            for (int i = 0; i < loops; i++)
            {
                yield return null;
                action();
            }
        }
        
        private static IEnumerator DelayedFrameAction(this MonoBehaviour mono, int frames, Action action)
        {
            for (int i = 0; i < frames; i++)
            {
                yield return null;
            }
            action();
        }
        
        private static IEnumerator RepeatedDoubleAction(this MonoBehaviour mono, float delay1, Action action1, float delay2, Action action2, int loops)
        {
            for (int i = 0; i < loops; i++)
            {
                yield return new WaitForSeconds(delay1);
                action1();
                yield return new WaitForSeconds(delay2);
                action2();
            }
        }
        
        private static IEnumerator EndOfFrameAction(this MonoBehaviour mono, Action action)
        {
            yield return new WaitForEndOfFrame();
            action();
        }
    }
}