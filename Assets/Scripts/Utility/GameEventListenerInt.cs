using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListenerInt : GameEventListener<int>
{
    protected override void OnEnable()
    {
        Event.AddListener(this);
    }

    protected override void OnDisable()
    {
        Event.RemoveListener(this);
    }
}
