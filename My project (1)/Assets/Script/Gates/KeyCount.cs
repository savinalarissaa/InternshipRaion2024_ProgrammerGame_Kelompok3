using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class KeyCount : MonoBehaviour
{
    public int keyCount;

    [SerializeField] private int MaxAmount = 1;

    void Start()
    {
        keyCount = 0;
    }

    void Update()
    {        
        if (keyCount >= MaxAmount)
        {
            DoorOpens.Invoke();
            Debug.Log("keyCount >= MaxAmount");
        }
    }

    public void addCount()
    {
        if (keyCount <= MaxAmount) 
        { 
            keyCount += 1;
            Debug.Log("Counted : " + keyCount);
        }
    }

    //public void DoorOpen()
    //{
    //    ExitDoor.SetActive(true);
    //}

    public UnityEvent DoorOpens;

}
