using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string NextSceneName;
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(NextSceneName);
    }
}
