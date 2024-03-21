using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool OnPause = false;

    public GameObject pauseMenuUI;
    public GameObject GameOverMenu;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (OnPause)
            {
                Resume();
            } else
            {
                Pause();
            }
        } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        OnPause = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        OnPause = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverMenu.SetActive(true);
    }

}
