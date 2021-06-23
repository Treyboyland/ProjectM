using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultipleNumberProblem", menuName = "Problem/Multiple Number")]
public class MultipleNumberProblem : ProblemCreator
{
    [SerializeField]
    Vector2Int numberRange;

    [SerializeField]
    int numbersToGenerate;

    public override List<int> GetProblem()
    {
        List<int> toReturn = new List<int>();
        for (int i = 0; i < numbersToGenerate; i++)
        {
            toReturn.Add(UnityEngine.Random.Range(numberRange.x, numberRange.y));
        }
        return toReturn;
    }
}
