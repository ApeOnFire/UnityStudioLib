using Sirenix.OdinInspector;
using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class SimpleSpawn : MonoBehaviour
    {
        public GameObject Prefab;
        [Title("Optional")]
        [InfoBox("If not set, the current transform will be used.")]
        public Transform SpawnPoint;
        public Transform SpawnRotation;
        public bool SpawnOnStart;
        public bool SpawnOnEnable;
        
        private void Start()
        {
            if (SpawnOnStart)
            {
                Spawn();
            }
        }
        
        private void OnEnable()
        {
            if (SpawnOnEnable)
            {
                Spawn();
            }
        }
        
        [Button]
        public void Spawn()
        {
            var spawnPoint = SpawnPoint != null ? SpawnPoint.position : transform.position;
            var spawnRotation = SpawnRotation != null ? SpawnRotation.rotation : transform.rotation;
            Instantiate(Prefab, spawnPoint, spawnRotation);
        }
    }
}