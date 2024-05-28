using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LostPanel : MonoBehaviour
{
    public GameObject lostpanel;
   public void OnRestart()
    {
        lostpanel.SetActive(false);
        ScoreManager.instance.player1Score = 0;
        ScoreManager.instance.player2Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void OnMainMneu()
    {
        lostpanel.SetActive(false); 
        SceneManager.LoadScene("Main Menu", 0);
    }

    public void Quit()
    {
        lostpanel.SetActive(false);
        Debug.Log("application quit ");
        Application.Quit();
    }
}
