using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string levelType;
    [SerializeField] private string levelName;

    private void Start()
    {
        if ((levelType == "fire" && GameManager.fireDone) ||
            (levelType == "water" && GameManager.waterDone) ||
            (levelType == "air" && GameManager.airDone) ||
            (levelType == "earth" && GameManager.earthDone)
            )
        {
            changeButtonInteractibility.Invoke();
        }
    }

    public void LoadLevel(){

        SceneManager.LoadScene(levelName);
    }

    public UnityEvent changeButtonInteractibility;
}
