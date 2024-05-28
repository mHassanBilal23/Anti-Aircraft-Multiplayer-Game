using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    public Button level2Button;
    public Button level3Button;


    void Start()
    {

        UpdateButtonInteractivity();
    }


    void Update()
    {

    }


   public void UpdateButtonInteractivity()
    {
       
        bool isLevel2Unlocked = PlayerPrefs.GetInt("HighScore", SoreCounter.HighScoreValue) > 10;
        
        bool isLevel3Unlocked = PlayerPrefs.GetInt("HighScore", SoreCounter.HighScoreValue) > 20; // You can modify this condition based on your requirements

       
        level2Button.interactable = isLevel2Unlocked;
        level3Button.interactable = isLevel3Unlocked;
    }
   public void ONlevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
  public  void ONlevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void ONlevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void onBack()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void onEndLess()
    {
        SceneManager.LoadScene("Player Selection");
    }
}