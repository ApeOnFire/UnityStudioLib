using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class ReparentChild : MonoBehaviour
    {
        public Transform Child;
        public Transform NewParent;
        
        public void ReparentNow()
        {
            Child.SetParent(NewParent, true);
        }
    }
}