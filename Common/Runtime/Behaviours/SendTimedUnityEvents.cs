using System;
using System.Collections;
using AFStudio.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace AFStudio.Common.Behaviours
{
    public class SendTimedUnityEvents : MonoBehaviour
    {
        public bool StartOnEnable;
        [Tooltip("Whether to restart the timers when StartTimers() is called.")]
        public RetriggerBehaviour RestartOnRetrigger;
        public Timer[] Timers;
        
        private int _numTimesTriggered;
        [SerializeField, ReadOnly] private bool _timersRunning;

        [FoldoutGroup("Debug"), Button, DisableInEditorMode]
        public void StartTimers()
        {
            if (RestartOnRetrigger == RetriggerBehaviour.Never && _numTimesTriggered > 0)
            {
                ApeLog.Log("Timers were triggered previously and will not retrigger.");
                return;
            }
            
            if (RestartOnRetrigger != RetriggerBehaviour.Always && _timersRunning)
            {
                ApeLog.Log("Timers are currently running and will not retrigger.");
                return;
            }

            ApeLog.Log($"Starting timers on {name}.");
            
            StopAllCoroutines();
            
            foreach (var timer in Timers)
            {
                timer.RunningCoroutine = FireEventAfterTime(timer);
                StartCoroutine(timer.RunningCoroutine);
            }
            _timersRunning = true;
            _numTimesTriggered++;
        }
        
        [FoldoutGroup("Debug"), Button, DisableInEditorMode]
        public void StopAndResetTimers()
        {
            StopAllCoroutines();
            _timersRunning = false;
            _numTimesTriggered = 0;
        }

        private void OnEnable()
        {
            if (StartOnEnable && Application.isPlaying)
            {
                StartTimers();
            }
        }

        private IEnumerator FireEventAfterTime(Timer timer)
        {
            do
            {
                var duration = timer.Duration + UnityEngine.Random.Range(-timer.Variance, timer.Variance);
                yield return new WaitForSeconds(duration);
                timer.Event?.Invoke();
            } while (timer.Repeat);
            
            // Check if all finished
            
            timer.RunningCoroutine = null;
            var allTimersFinished = true;
            foreach (var t in Timers)
            {
                if (t.RunningCoroutine != null)
                {
                    allTimersFinished = false;
                    break;
                }
            }
            if (allTimersFinished)
            {
                _timersRunning = false;
            }
        }

        [Serializable]
        public class Timer
        {
            public float Duration;
            public float Variance;
            public bool Repeat;
            public UnityEvent Event;
            
            public IEnumerator RunningCoroutine { get; set; }
        }

        public enum RetriggerBehaviour
        {
            Never,
            Always,
            OnlyIfAllFinished
        }
    }
}