using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBug : MonoBehaviour
{
    [SerializeField]
    Animator containerAnimator;

    [SerializeField]
    int amount;

    [SerializeField]
    Player player;

    private void OnMouseDown()
    {
        Spawn();
    }

    public void Spawn()
    {
        containerAnimator.SetTrigger("Open");
        player.SpawnBit(amount);
    }
}
