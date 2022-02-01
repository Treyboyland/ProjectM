using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinNumber : Number
{
    [SerializeField]
    int number;

    public override int Value { get { return number; } set { number = value; } }
}
