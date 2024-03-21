using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool bossReady;
    public static bool fireDone = false;
    public static bool waterDone = false;
    public static bool airDone = false;
    public static bool earthDone = false;

    private int AmountFinished;
    [SerializeField] private GameObject gameManager;

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
            Debug.Log(bossReady);
        }
    }

    public void FinishedLevel()
    {
        AmountFinished++;
        Debug.Log(AmountFinished);
    }

    public void SetFinish(int LevelID)
    {
        switch (LevelID)
        {
            case 3: fireDone = true; Debug.Log(fireDone);
                break;
            case 4: airDone = true; break;
            case 5: waterDone = true; break;
            case 6: earthDone = true; break;
            default: Debug.Log("SceneNotFound");break;
            
        }
    }

    public void RestartGame()
    {
        AmountFinished = 0;
        fireDone = airDone = earthDone = waterDone = bossReady = false;
    }
}