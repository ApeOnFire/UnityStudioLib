using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class SetFloatToValue : MonoBehaviour
    {
        public FloatVariable Subject;
        
        public void SetToValue(float value)
        {
            Subject.SetValue(value);
        }
    }
}