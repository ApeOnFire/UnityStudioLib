using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Conditions
{
    [CreateAssetMenu(menuName = "Unity Atoms/Conditions/FloatPair/FloatPairCondition")]
    public class FloatPairCondition : AtomCondition<FloatPair>
    {
        [Header("Change")]
        public bool Increased;
        public bool Decreased;
        [Header("Previous")]
        public bool WasEqualToY;
        public bool WasGreaterThanOrEqToY;
        public bool WasLessThanOrEqToY;
        public int Y;
        [Header("Now")]
        public bool EqualToXNow;
        public bool GreaterThanOrEqToXNow;
        public bool LessThanOrEqToXNow;
        public int X;

        public override bool Call(FloatPair t)
        {
            // NOTE: Item1 is the *current* value, Item2 is the previous value.
            if (Increased && t.Item1 <= t.Item2) return false;
            if (Decreased && t.Item1 >= t.Item2) return false;
            
            if (WasEqualToY && t.Item2 != Y) return false;
            if (WasGreaterThanOrEqToY && t.Item2 < Y) return false;
            if (WasLessThanOrEqToY && t.Item2 > Y) return false;
            
            if (EqualToXNow && t.Item1 != X) return false;
            if (GreaterThanOrEqToXNow && t.Item1 < X) return false;
            if (LessThanOrEqToXNow && t.Item1 > X) return false;

            return true;
        }
    }
}