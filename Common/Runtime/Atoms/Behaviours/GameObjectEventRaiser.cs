using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class GameObjectEventRaiser : MonoBehaviour
    {
        [Header("Call RaiseEvent(GameObject) to raise this event:")]
        public GameObjectEvent Event;
        public float Delay = 0f;

        public void RaiseEvent(GameObject go)
        {
            if (Delay > 0f)
            {
                StartCoroutine(RaiseEventAfterDelay(go));
            }
            else
            {
                Event.Raise(go);
            }
        }
        
        private IEnumerator RaiseEventAfterDelay(GameObject go)
        {
            yield return new WaitForSeconds(Delay);
            Event.Raise(go);
        }
    }
}