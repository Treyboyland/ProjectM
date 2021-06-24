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

    protected virtual void Clean()
    {
        for (int i = listeners.Count - 1; i > 0; i--)
        {
            if (listeners[i] == null)
            {
                listeners.RemoveAt(i);
            }
        }
    }

    protected virtual void OnEnable()
    {
        Clean();
    }

    public virtual void AddListener(GameEventListener<T> listener)
    {
        Debug.LogWarning(name + ": Listener added: " + listener.name);
        // foreach (var obj in listeners)
        // {
        //     if (obj == listener)
        //     {
        //         return;
        //     }
        // }

        listeners.Add(listener);
        Clean();
    }

    public virtual void RemoveListener(GameEventListener<T> listener)
    {
        Debug.LogWarning(name + " Remove Listener: " + listener.name);
        for (int i = listeners.Count - 1; i > 0; i--)
        {
            if (listeners[i] == listener)
            {
                listeners.RemoveAt(i);
            }
        }
        Clean();
    }

    public virtual void Invoke(T value)
    {
        Debug.LogWarning(name + "Invoking");
        foreach (var listener in listeners)
        {
            if (listener != null)
            {
                Debug.LogWarning(name + " Test: " + listener);
                Debug.LogWarning(name + "Invokng Listener: " + listener.gameObject.name);
                listener.Response.Invoke(value);
            }
        }
    }
}
