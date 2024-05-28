using System.Collections;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 4f; 
    public float spawnHeight = 8f; 
    public AudioClip spawnSound; 
    private AudioSource audioSource; 
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnEnemy()
    {
        float randomX = Random.Range(8f, 8f);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        enemyRb.velocity = new Vector2(-10, 0f);
        StartCoroutine(DestroyEnemyWhenOffscreen(enemy));

        // Play the spawn sound
        PlaySpawnSound();
    }

    IEnumerator DestroyEnemyWhenOffscreen(GameObject enemy)
    {
        while (true)
        {
            yield return null; 

          
            if (enemy == null || !enemy.activeSelf)
            {
                yield break; 
            }

           
            if (enemy.transform.position.x < -13f) 
            {
                Destroy(enemy);
                yield break; // Exit the coroutine
            }
        }
    }

    void PlaySpawnSound()
    {
        if (spawnSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }
}
