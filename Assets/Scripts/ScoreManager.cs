using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ScoreManager : MonoBehaviourPunCallbacks
{
    public static ScoreManager instance;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
   

    public int player1Score = 0;
    public int player2Score = 0;

    // public GameObject winPanel; // Commented out for now

    private void Awake()
    {
        // Singleton pattern
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // Optional: if you want it to persist across scenes
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int playerID, int score)
    {
        if (playerID == 1)
        {
            player1Score += score;
            UpdateScoreText(player1ScoreText, player1Score);
        }
        else if (playerID == 2)
        {
            player2Score += score;
            UpdateScoreText(player2ScoreText, player2Score);
        }

        photonView.RPC("UpdateScoreRPC", RpcTarget.Others, playerID, player1Score, player2Score);
    }

    [PunRPC]
    private void UpdateScoreRPC(int playerID, int p1Score, int p2Score)
    {
        player1Score = p1Score;
        player2Score = p2Score;

        UpdateUI();
    }

    private void UpdateScoreText(TextMeshProUGUI scoreText, int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateUI()
    {
        UpdateScoreText(player1ScoreText, player1Score);
        UpdateScoreText(player2ScoreText, player2Score);
    }

    /*private void CheckWinCondition()
    {
        if (player1Score >= 16 || player2Score >= 16)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }*/

    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateUI();
    }
}
