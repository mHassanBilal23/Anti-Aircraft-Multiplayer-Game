using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance;

    public GameObject player_prefab;
    public List<Transform> spawn_points; // List of spawn points
    private Dictionary<int, Transform> playerSpawnPoints = new Dictionary<int, Transform>();

    private void Awake()
    {
        // Implementing a singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: If you want the spawner to persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        if (player_prefab == null || spawn_points == null || spawn_points.Count == 0)
        {
            Debug.LogError("Player prefab or spawn points are not set.");
            return;
        }

        // Determine the spawn point based on the player's ActorNumber
        int actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        int spawnIndex = actorNumber % spawn_points.Count; // Ensures we don't go out of bounds

        Transform spawnPoint = spawn_points[spawnIndex];
        playerSpawnPoints[actorNumber] = spawnPoint; // Store the spawn point in the dictionary

        PhotonNetwork.Instantiate(player_prefab.name, spawnPoint.position, spawnPoint.rotation);
    }

    // Method to get the player's spawn point
    public Transform GetPlayerSpawnPoint(int playerID)
    {
        if (playerSpawnPoints.TryGetValue(playerID, out Transform spawnPoint))
        {
            return spawnPoint;
        }
        return null;
    }
}
