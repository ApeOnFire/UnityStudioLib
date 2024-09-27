using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class SetIntToValue : MonoBehaviour
    {
        public IntVariable Subject;
        
        public void SetToValue(int value)
        {
            Subject.SetValue(value);
        }
    }
}