using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCount : MonoBehaviour
{
    public int keyCount;
    [SerializeField] private int MaxAmount;

    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(keyCount);
        
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
        }
        
    }
}
