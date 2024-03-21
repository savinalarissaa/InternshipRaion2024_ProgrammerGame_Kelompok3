using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the Unity Editor
    public Transform spawnPoint; // Assign the spawn point in the Unity Editor
    
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        // Check if the player prefab and spawn point are assigned
        if (playerPrefab != null && spawnPoint != null)
        {
            // Spawn the player at the designated spawn point
            GameObject player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Player prefab or spawn point not assigned in PlayerSpawner!");
        }
    }
}

