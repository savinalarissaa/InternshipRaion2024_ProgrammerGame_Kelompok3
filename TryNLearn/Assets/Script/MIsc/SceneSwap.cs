using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public string sceneName; // The name of the scene to load

    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName); // Load the scene specified by sceneName
    }
}
