using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Actions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Raise Event/RaiseVoidEvent")]
    public class RaiseVoidEvent : AtomAction
    {
        public VoidEvent Event;
        
        public override void Do()
        {
            Event.Raise();
        }
    }
}