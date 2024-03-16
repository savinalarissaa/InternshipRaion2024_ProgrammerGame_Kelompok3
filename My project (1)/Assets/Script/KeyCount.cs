using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCount : MonoBehaviour
{
    public int keyCount;
    [SerializeField] private int MaxAmount;

    void Start()
    {
        keyCount = 0;
    }

    void Update()
    {        
        if (keyCount >= MaxAmount)
        {
            Debug.Log("Door Open");
        }
    }

    public void addCount(int amount)
    {
        if (keyCount <= MaxAmount) 
        { 
            Debug.Log("Counted");
            keyCount += amount;
            Debug.Log(keyCount);
        }
    }
}
