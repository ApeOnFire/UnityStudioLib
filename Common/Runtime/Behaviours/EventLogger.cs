using System;
using System.Collections.Generic;
using AFStudio.Common.Utils;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Void = UnityAtoms.Void;

namespace AFStudio.Common.Behaviours
{
    public class EventLogger : MonoBehaviour
    {
        public List<EventItem<VoidEvent, Void>> VoidEvents = new();
        public List<EventItem<IntEvent, int>> IntEvents = new();
        public List<EventItem<FloatEvent, float>> FloatEvents = new();
        public List<EventItem<StringEvent, string>> StringEvents = new();
        public List<EventItem<GameObjectEvent, GameObject>> GameObjectEvents = new();

        private void Awake()
        {
            RegisterAll();
        }
        
        private void RegisterAll()
        {
            foreach (var eventItem in VoidEvents)
            {
                eventItem.RegisterListener();
            }
            foreach (var eventItem in IntEvents)
            {
                eventItem.RegisterListener();
            }
            foreach (var eventItem in FloatEvents)
            {
                eventItem.RegisterListener();
            }
            foreach (var eventItem in StringEvents)
            {
                eventItem.RegisterListener();
            }
            foreach (var eventItem in GameObjectEvents)
            {
                eventItem.RegisterListener();
            }
        }
        
        private void UnregisterAll()
        {
            foreach (var eventItem in VoidEvents)
            {
                eventItem.UnregisterListener();
            }
            foreach (var eventItem in IntEvents)
            {
                eventItem.UnregisterListener();
            }
            foreach (var eventItem in FloatEvents)
            {
                eventItem.UnregisterListener();
            }
            foreach (var eventItem in StringEvents)
            {
                eventItem.UnregisterListener();
            }
            foreach (var eventItem in GameObjectEvents)
            {
                eventItem.UnregisterListener();
            }
        }
    }

    [Serializable]
    public class EventItem<T,TD> : IAtomListener<TD> where T : AtomEvent<TD>
    {
        public T Event;
        
        public void OnEventRaised(TD item)
        {
            try
            {
                ApeLog.Log(item switch
                {
                    Void => $"Event: {Event.name}",
                    GameObject => $"Event: {Event.name}: {((GameObject)(object)item).name}",
                    _ => $"Event: {Event.name}: {item}"
                });
            }
            catch (Exception)
            {
                // ignored
            }
        }
        
        public void RegisterListener()
        {
            Event.RegisterListener(this, false);
        }
        
        public void UnregisterListener()
        {
            Event.UnregisterListener(this);
        }
    }
}