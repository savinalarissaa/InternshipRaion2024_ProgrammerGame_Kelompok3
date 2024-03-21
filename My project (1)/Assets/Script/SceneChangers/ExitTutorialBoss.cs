using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTutorialBoss : MonoBehaviour
{
    [SerializeField] private string NextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GoToScene();
        }
    }

    private void GoToScene()
    {
        Time.timeScale = 1f;
        GameManager.Instance.RestartGame();
        SceneManager.LoadScene(NextScene);
    }
}
