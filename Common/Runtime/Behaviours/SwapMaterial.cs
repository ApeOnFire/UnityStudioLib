using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class SwapMaterial : MonoBehaviour
    {
        public Renderer Subject;
        public Material Material;
        
        [Button]
        public void SwapNow()
        {
            Subject.material = Material;
        }

        private void Reset()
        {
            Subject = GetComponent<Renderer>();
        }
    }
}