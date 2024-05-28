using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooting : MonoBehaviourPun
{
    public Transform FirePoint;
    public GameObject bulletPrefabPlayer1;
    public GameObject bulletPrefabPlayer2;
    public float bulletForce = 20f;
    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!photonView.IsMine) // Check if it's the local player's instance
            return;

        // For mouse fire
        if (Input.GetButtonDown("Fire1"))
        {
            // Call the Shoot method directly for the local player
            Shoot(PhotonNetwork.LocalPlayer.ActorNumber);
        }
    }

    void Shoot(int playerID)
    {
        // Play the shoot sound
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // Determine which bullet prefab to use based on the player's ID
        GameObject bulletPrefab;
        if (playerID == 1)
        {
            bulletPrefab = bulletPrefabPlayer1;
        }
        else if (playerID == 2)
        {
            bulletPrefab = bulletPrefabPlayer2;
        }
        else
        {
            Debug.LogError("Invalid player ID: " + playerID);
            return;
        }

        // Instantiate the bullet prefab locally
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

        // Set the shooter player ID for the bullet
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetShooterPlayerID(playerID);
        }

        // Add force to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
