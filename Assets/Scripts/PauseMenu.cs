using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuUI;


    public void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;

    }
    public void MainMenu()
    {

        PauseMenuUI.SetActive(false);
     
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        PauseMenuUI.SetActive(false);
        Debug.Log("application quit ");
        Application.Quit();
    }
}
