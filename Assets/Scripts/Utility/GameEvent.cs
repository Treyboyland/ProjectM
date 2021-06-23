using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Game Event", order = -1)]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
        foreach (var obj in listeners)
        {
            if (obj == listener)
            {
                return;
            }
        }

        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        for (int i = listeners.Count - 1; i > 0; i--)
        {
            if (listeners[i] == listener)
            {
                listeners.RemoveAt(i);
            }
        }
    }

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}



public class GameEvent<T> : ScriptableObject
{
    protected List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();

    public void AddListener(GameEventListener<T> listener)
    {
        foreach (var obj in listeners)
        {
            if (obj == listener)
            {
                return;
            }
        }

        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener<T> listener)
    {
        for (int i = listeners.Count - 1; i > 0; i--)
        {
            if (listeners[i] == listener)
            {
                listeners.RemoveAt(i);
            }
        }
    }

    public void Invoke(T value)
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke(value);
        }
    }
}
