using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class SyncGameObjectToVariable : MonoBehaviour
    {
        public GameObject Subject;
        public GameObjectVariable Variable;

        private void Awake()
        {
            Variable.Value = Subject;
        }
        
        private void OnDestroy()
        {
            if (Variable.Value == Subject)
            {
                Variable.Value = null;
            }
        }

        private void Reset()
        {
            Subject = gameObject;
        }
    }
}