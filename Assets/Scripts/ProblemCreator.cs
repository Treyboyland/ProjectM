using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProblemCreator : ScriptableObject
{
    public abstract List<int> GetProblem();
}
