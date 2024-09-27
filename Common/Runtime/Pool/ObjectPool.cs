using System.Collections.Generic;
using UnityEngine;

namespace AFStudio.Common.Pool
{
    public class ObjectPool<T> : IObjectPool where T : PooledObject
    {
        private readonly List<T> _prefabs;
        private readonly Queue<T> _pool = new();
        private readonly PoolContainer _poolParent;
        private readonly int _initialPoolSize;
        private int _objectCount;

        public ObjectPool(T prefab, Transform poolParent, int initialPoolSize = 10) : this(new List<T> {prefab}, poolParent, initialPoolSize) { }
        
        public ObjectPool(List<T> prefabs, Transform poolParent, int initialPoolSize = 10)
        {
            _prefabs = prefabs;
            _poolParent = poolParent.gameObject.AddComponent<PoolContainer>();
            _initialPoolSize = initialPoolSize;
            for (var i = 0; i < initialPoolSize; i++)
            {
                var obj = CreateObject(_poolParent.transform);
                _pool.Enqueue(obj);
            }
        }

        private T CreateObject(Transform parent)
        {
            var random = _prefabs[Random.Range(0, _prefabs.Count)];
            var obj = Object.Instantiate(random, parent);
            obj.gameObject.SetActive(false);
            obj.name = $"(ID{_objectCount}) {random.name}";
            obj.SetPool(this);
            _objectCount++;
            if (_objectCount % _initialPoolSize == 0 && _objectCount > _initialPoolSize)
                Debug.LogWarning($"Pool of '{_prefabs[0].name}' expended to {_objectCount} objects ({_objectCount / _initialPoolSize}x initial).");
            return obj.GetComponent<T>();
        }

        public T GetObject(Transform parent)
        {
            T obj;
            if (_pool.Count <= 0)
                obj = CreateObject(parent);
            else
            {
                obj = _pool.Dequeue();
                obj.transform.SetParent(parent);
            }

            obj.gameObject.SetActive(true);
            return obj;
        }

        public void ReturnObject(PooledObject obj)
        {
            if (obj)
            {
                obj.transform.SetParent(_poolParent.transform);
                obj.gameObject.SetActive(false);
                _pool.Enqueue((T)obj);
            }
            else
            {
                Debug.LogWarning($"Attempted to return a destroyed object to the '{_prefabs[0].name}' pool.");
                _objectCount--;
            }
        }

        public void DestroyPool()
        {
            foreach (var obj in _pool)
            {
                Object.Destroy(obj.gameObject);
            }

            _pool.Clear();
        }
    }

    public interface IObjectPool
    {
        void ReturnObject(PooledObject obj);
    }
}