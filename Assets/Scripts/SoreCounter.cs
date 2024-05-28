using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SoreCounter : MonoBehaviour
{
    public static int ScoreValue = 0;
    public static int HighScoreValue = 0;
    public Text Score;
    public Text high;

    void Start()
    {
        LoadHighScore();
        UpdateUI();
    }

    void Update()
    {
        if (ScoreValue > HighScoreValue)
        {
            HighScoreValue = ScoreValue;
            SaveHighScore();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        Score.text = "Score: " + ScoreValue;



        high.text = "High Score: " + HighScoreValue;
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScoreValue);
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        HighScoreValue = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ResetScore()
    {
        ScoreValue = 0;
        HighScoreValue = ScoreValue;
        SaveHighScore();
        UpdateUI();
    }
}

