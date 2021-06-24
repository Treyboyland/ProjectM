using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNumber : Number
{
    int value = 0;

    public override int Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            textBox.text = "" + value;
        }
    }

    [SerializeField]
    TMP_Text textBox;
}
