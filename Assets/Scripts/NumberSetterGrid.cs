using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSetterGrid : MonoBehaviour
{
    [SerializeField]
    Vector2 offsets;

    [SerializeField]
    int numPerRow;

    [SerializeField]
    NumberPool playerNumberPool;

    [SerializeField]
    GameEvent spawnsCleared;

    int numControlled = 0;

    Vector2 currentOffsets;

    private void Start()
    {
        currentOffsets = offsets;
    }
    private void Update()
    {
        if (currentOffsets != offsets)
        {
            currentOffsets = offsets;
            Adjust();
        }
    }

    void Adjust()
    {
        var nums = GetComponentsInChildren<Number>();
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i].transform.localPosition = new Vector3((i % numPerRow) * offsets.x, (i / numPerRow) * offsets.y);
        }
    }

    public void Summon(int value)
    {
        var num = playerNumberPool.SpawnNumber(value);
        num.transform.SetParent(transform);
        num.transform.localPosition = new Vector3((numControlled % numPerRow) * offsets.x, (numControlled / numPerRow) * offsets.y);
        num.gameObject.SetActive(true);
        numControlled++;
    }

    public void ClearAll()
    {
        Debug.LogWarning(gameObject.name + ": Clearing");
        numControlled = 0;
        var nums = GetComponentsInChildren<Number>();
        foreach (var num in nums)
        {
            num.gameObject.SetActive(false);
        }
        if (spawnsCleared != null)
        {
            spawnsCleared.Invoke();
        }
    }
}
