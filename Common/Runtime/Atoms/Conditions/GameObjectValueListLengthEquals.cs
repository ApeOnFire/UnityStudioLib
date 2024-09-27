using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Conditions
{
    [EditorIcon("atom-icon-sand")]
    [CreateAssetMenu(menuName = "Unity Atoms/Conditions/GameObject/LengthEquals", fileName = "LengthEquals")]
    public class GameObjectValueListLengthEquals : AtomCondition
    {
        // Can be set via the Inspector
        public GameObjectValueList List;
        public int Length;

        public override bool Call()
        {
            return List.Count == Length;
        }
    }
}