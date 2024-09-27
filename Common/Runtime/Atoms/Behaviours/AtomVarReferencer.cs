using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class AtomVarReferencer : MonoBehaviour
    {
        public IntReference IntReference;
        public FloatReference FloatReference;

        public int GetIntValue() => IntReference.Value;
        public void SetInt(int value) => IntReference.Value = value;
        public float GetFloatValue() => FloatReference.Value;
        public void SetFloat(float value) => FloatReference.Value = value;
    }
}