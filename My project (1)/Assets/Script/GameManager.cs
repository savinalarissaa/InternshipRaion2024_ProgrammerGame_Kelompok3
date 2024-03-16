using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool bossReady;
    private int AmountFinished;

    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        AmountFinished = 0;
        bossReady = false;
    }

    void Update()
    {
        if (AmountFinished == 4)
        {
            bossReady = true;
        }
    }
    public void FinishedLevel()
    {
        AmountFinished++;
        Debug.Log(AmountFinished);
    }
}
