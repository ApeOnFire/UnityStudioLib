using System;
using UnityEngine;
using UnityEngine.Events;

namespace AFStudio.Common.Utils
{
    [Serializable] public class UnityIntEvent : UnityEvent<int> { }
    [Serializable] public class UnityFloatEvent : UnityEvent<float> { }
    [Serializable] public class UnityBoolEvent : UnityEvent<bool> { }
    [Serializable] public class UnityStringEvent : UnityEvent<string> { }
    [Serializable] public class UnityGameObjectEvent : UnityEvent<GameObject> { }
}