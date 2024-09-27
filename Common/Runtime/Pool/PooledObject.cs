using UnityEngine;

namespace AFStudio.Common.Pool
{
    public class PooledObject : MonoBehaviour
    {
        private IObjectPool _pool;

        public void SetPool(IObjectPool pool)
        {
            _pool = pool;
        }

        /// <summary>
        /// This should be called when the object is no longer needed.
        /// The object will be disabled and re-parented.
        /// </summary>
        public virtual void ReturnToPool()
        {
            _pool?.ReturnObject(this);
        }
    }
}