using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    ON_MOVE = 0
}

public static class EventManager
{
    private static Dictionary<EventType, System.Action> eventDictionary = new Dictionary<EventType, System.Action>();

    //Used for subscribing to events
    public static void Subscribe(EventType _type, System.Action _function)
    {
        if (!eventDictionary.ContainsKey(_type))
        {
            eventDictionary.Add(_type, null);
        }
        eventDictionary[_type] += _function;
    }

    //Used for unsubscribing from events
    public static void Unsubscribe(EventType _type, System.Action _function)
    {
        if (eventDictionary.ContainsKey(_type) && eventDictionary[_type] != null)
        {
            eventDictionary[_type] -= _function;
        }
    }

    //Used for invoking events
    public static void Invoke(EventType _type)
    {
        eventDictionary[_type]?.Invoke();
    }
}
