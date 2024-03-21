using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class BossLevelButton : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.bossReady)
        {
            buttonInteractable.Invoke();
        } else
        {
            buttonDisabled.Invoke();
        }
    }

    public UnityEvent buttonInteractable;
    public UnityEvent buttonDisabled;

    public void StartBoss()
    {
        if (GameManager.bossReady)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Boss_Level");
        } 
        else
        {
            Debug.Log("Not Ready");
        }   
    }
}
