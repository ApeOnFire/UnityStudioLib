using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class ReparentToMe : MonoBehaviour
    {
        public GameObject ObjectToReparent;
        public bool ReparentOnStart = true;

    
        void Start()
        {
            if (ReparentOnStart)
            {
                Reparent();
            }
        }

        public void Reparent()
        {
            ObjectToReparent.transform.SetParent(this.transform);
        }
    }
}
