using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleNumberProblem", menuName = "Problem/Single Number")]
public class SingleNumberProblem : ProblemCreator
{
    [SerializeField]
    Vector2Int numberRange;

    public override List<int> GetProblem()
    {
        var num = UnityEngine.Random.Range(numberRange.x, numberRange.y);
        return new List<int>() { num };
    }
}
