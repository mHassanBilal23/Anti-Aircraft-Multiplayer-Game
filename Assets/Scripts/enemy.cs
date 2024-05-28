using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float minFireInterval = 0.5f;
    public float maxFireInterval = 0.5f;
    public float initialDelay = 0f; 
    public AudioClip fireSound;
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        StartCoroutine(EnterAndFire());
    }

    IEnumerator EnterAndFire()
    {
        // Move the enemy to the left side of the screen
        transform.position = new Vector3(Random.Range(9f, 20f), transform.position.y, transform.position.z);

        // Calculate the adjusted initial delay
        float adjustedInitialDelay = Mathf.Min(initialDelay, 0.5f);

        // Wait for the adjusted initial delay
        yield return new WaitForSeconds(adjustedInitialDelay);

        // Start firing missiles
        StartCoroutine(FireRandomly());
    }

    IEnumerator FireRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minFireInterval, maxFireInterval));
            FireBullet();
        }
    }

    void FireBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

   
        PlayFireSound();
    }

    void PlayFireSound()
    {
        if (fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }
}
