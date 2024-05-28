using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame() 
    {
        SceneManager.LoadScene("LoadingScreen");
    }
    public void Quitgame()
    {
        Debug.Log("application quit ");
        Application.Quit();
    }
    public void OnlineGame()
    {
        SceneManager.LoadScene("Online_game");
    }

}
