using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class LivesScript_Online : MonoBehaviourPun
{
    public int lives = 5;
    public TextMeshProUGUI player1LivesText;
    public TextMeshProUGUI player2LivesText;
    public GameObject lostPanel;

    private void Start()
    {
        InitializeUI();
        UpdateLivesText();
    }

    private void InitializeUI()
    {
        // Ensure TextMeshPro elements are assigned
        if (player1LivesText == null || player2LivesText == null)
        {
            Debug.LogError("Lives Texts are not assigned to the script.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!photonView.IsMine) // Only the local player should handle their own lives
            return;

        if (other.CompareTag("missile"))
        {
            lives--;
            if (lives <= 0)
            {
                lostPanel.SetActive(true);
                Time.timeScale = 0f;
            }

            UpdateLivesText();
        }
    }

    private void UpdateLivesText()
    {
        int playerID = photonView.Owner.ActorNumber;

        if (photonView.IsMine)
        {
            if (playerID == 1)
            {
                player1LivesText.text = "Lives: " + lives;
            }
            else if (playerID == 2)
            {
                player2LivesText.text = "Lives: " + lives;
            }
        }
    }
}
