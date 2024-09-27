using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Assertions;

namespace AFStudio.Common.Atoms.Behaviours
{
    public class SyncActiveStateToList : MonoBehaviour
    {
        [InfoBox("This component will add/remove the GameObject to/from the list when enabled/disabled.")]
        [SerializeField]
        private GameObjectValueList _list = default;

        void OnEnable()
        {
            Assert.IsNotNull(_list);
            _list.Add(gameObject);
        }

        void OnDisable()
        {
            _list.Remove(gameObject);
        }
    }
}