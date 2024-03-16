using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string NextSceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
