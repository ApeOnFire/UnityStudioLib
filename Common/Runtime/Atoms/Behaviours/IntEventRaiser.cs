using AFStudio.Common.Utils;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class IntEventRaiser : MonoBehaviour
    {
        [Header("Call RaiseEvent() to raise this event:")]
        public IntEvent Event;
        
        public void RaiseEvent(int value) => Event.Raise(value);

        public void RaiseEventEndOfFrame(int value)
        {
            this.ScheduleEndOfFrame(() => Event.Raise(value));
        }
        
    }
}