using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class SetIntToHigherValue : MonoBehaviour
    {
        public IntVariable Subject;
        
        public void SetToHigherValue(int value)
        {
            if (value > Subject.Value)
            {
                Subject.SetValue(value);
            }
        }
    }
}