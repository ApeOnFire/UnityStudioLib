using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace AFStudio.Common.Behaviours
{
    public class UnityEventProxy : MonoBehaviour
    {
        public UnityEvent Event;
        
        [Button]
        public void Invoke()
        {
            Event.Invoke();
        }
    }
}