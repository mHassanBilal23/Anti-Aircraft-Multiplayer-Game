using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitEffect;

    // Store the player ID of the shooter
    private int shooterPlayerID;

    // Set the shooter player ID when the bullet is instantiated
    public void SetShooterPlayerID(int playerID)
    {
        shooterPlayerID = playerID;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Instantiate hit effect
        if (HitEffect != null)
        {
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }

        // Destroy the bullet
        Destroy(gameObject);

        // Check if the collided object is an enemy or missile
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("missile"))
        {
            // Update the score using the shooter's player ID
            ScoreManager.instance.AddScore(shooterPlayerID, 1);

            // Destroy the collided object
            Destroy(collision.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Destroy the bullet if it becomes invisible
        Destroy(gameObject);
    }
}
