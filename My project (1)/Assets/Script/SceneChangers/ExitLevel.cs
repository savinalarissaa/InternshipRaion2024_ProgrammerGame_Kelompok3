using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] private string NextSceneName;
    [SerializeField] private int LevelID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Start Next Scene");
            CompleteLevel();
            GameManager.Instance.FinishedLevel();
            GameManager.Instance.SetFinish(LevelID);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
