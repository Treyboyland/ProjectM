using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int maxNumSpawns;

    int currentSpawns = 0;

    public int CurrentSpawns { get { return currentSpawns; } set { currentSpawns = value; } }

    [SerializeField]
    GameEventInt spawnBit;

    int currentScore = 0;

    public int CurrentScore { get { return currentScore; } set { currentScore = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBit(int value)
    {
        if (currentSpawns < maxNumSpawns)
        {
            currentSpawns++;
            spawnBit.Invoke(value);
            currentScore += value;
        }
    }

    public void ModifyScore(int value)
    {
        CurrentScore += value;
    }
}
