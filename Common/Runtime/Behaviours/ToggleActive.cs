using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class ToggleActive : MonoBehaviour
    {
        public GameObject Subject;
        
        public void Toggle()
        {
            Subject.SetActive(!Subject.activeSelf);
        }
    }
}