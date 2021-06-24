using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener<T> : MonoBehaviour
{
    [SerializeField]
    protected GameEvent<T> Event;

    public UnityEvent<T> Response;

    protected virtual void OnEnable()
    {
        Event.AddListener(this);
    }

    protected virtual void OnDisable()
    {
        Event.RemoveListener(this);
    }
}
