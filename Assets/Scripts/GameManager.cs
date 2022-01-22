using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    ProblemCreator problemCreator;

    [SerializeField]
    Player player;

    [SerializeField]
    GameEvent onPlayerSuccess;

    [SerializeField]
    GameEvent onPlayerFail;

    [SerializeField]
    GameEventInt onSummonEnemyNumber;

    [SerializeField]
    GameEvent onProblemComplete;

    public ProblemCreator ProblemCreator
    {
        get { return problemCreator; }
        set
        {
            if (!hasProblem)
            {
                problemCreator = value;
            }
        }
    }

    bool hasProblem = false;

    int numIndex = 0;

    List<int> currentNums;

    public void CreateProblem(bool skip)
    {
        if (hasProblem && !skip)
        {
            return;
        }
        hasProblem = true;
        numIndex = 0;
        currentNums = problemCreator.GetProblem();
        onSummonEnemyNumber.Invoke(currentNums[numIndex]);
    }

    int GetCurrentSolution()
    {
        if (!hasProblem)
        {
            return int.MaxValue;
        }
        int total = 0;
        for (int i = 0; i < numIndex + 1; i++)
        {
            total += currentNums[i];
        }
        return total;
    }

    public void AttemptSolve()
    {
        var playerNum = player.CurrentScore;
        var sum = GetCurrentSolution();
        Debug.LogWarning("Player: " + playerNum + " " + sum);
        if (hasProblem && playerNum == sum)
        {
            onPlayerSuccess.Invoke();
        }
        else
        {
            onPlayerFail.Invoke();
        }
    }

    public void GetNextNumber()
    {
        numIndex++;
        if (numIndex >= currentNums.Count)
        {
            onProblemComplete.Invoke();
        }
        else
        {
            onSummonEnemyNumber.Invoke(currentNums[numIndex]);
        }
    }

    public void CompleteProblem()
    {
        hasProblem = false;
    }
}
