using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Actions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/AddStaticToInt")]
    public class AddStaticToInt : AtomAction
    {
        public IntVariable IntVariable;
        public IntReference IntToAdd;
        
        public override void Do()
        {
            IntVariable.Value += IntToAdd.Value;
        }
    }
}