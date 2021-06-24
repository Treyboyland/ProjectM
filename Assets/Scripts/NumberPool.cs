using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPool : MonoBehaviour
{
    [SerializeField]
    Number numberPrefab;

    [SerializeField]
    int initialSize;

    List<Number> pool = new List<Number>();

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GetNumber();
        }
    }

    Number GetNumber()
    {
        var num = Instantiate(numberPrefab, transform) as Number;
        num.gameObject.SetActive(false);
        pool.Add(num);
        return num;
    }

    public Number SpawnNumber(int value)
    {
        foreach (var num in pool)
        {
            if (!num.gameObject.activeInHierarchy)
            {
                return num;
            }
        }

        return GetNumber();
    }

    public void SpawnNumberNoReturn(int value)
    {
        Debug.LogWarning("Spawning");
        var num = SpawnNumber(value);
        num.Value = value;
        num.gameObject.SetActive(true);
    }
}
