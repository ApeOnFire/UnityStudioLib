using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class AddToIntVariable : MonoBehaviour
    {
        public IntVariable Variable;
        [Tooltip("The value to add to the variable when AddDefault() is called.")]
        public int DefaultValue;
        
        public void Add(int value)
        {
            Variable.Value += value;
        }
        
        public void AddDefault()
        {
            Variable.Value += DefaultValue;
        }
    }
}