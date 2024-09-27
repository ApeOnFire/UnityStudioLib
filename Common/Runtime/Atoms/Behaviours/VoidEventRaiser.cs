using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class VoidEventRaiser : MonoBehaviour
    {
        [Header("Call RaiseEvent() to raise this event:")]
        public VoidEvent Event;
        
        public void RaiseEvent() => Event.Raise();

        public void RaiseEventWithDelay(float delay)
        {
            StartCoroutine(RaiseAfterDelay(delay));
        }
        
        public void RaiseEventWithDelayEndOfFrame(float delay)
        {
            StartCoroutine(RaiseAfterDelay(delay, true));
        }
        
        private IEnumerator RaiseAfterDelay(float delay, bool waitForEndOfFrame = false)
        {
            yield return new WaitForSeconds(delay);
            if (waitForEndOfFrame) yield return new WaitForEndOfFrame();
            Event.Raise();
        }
    }
}