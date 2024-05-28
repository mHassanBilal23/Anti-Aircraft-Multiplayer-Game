using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinPanel: MonoBehaviour
{
    public GameObject winpanel;
  public void OnnextLevel()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene("Player Selection");
    }
    public void OnMainMneu()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        winpanel.SetActive(false);
        Debug.Log("application quit ");
        Application.Quit();
    }
}
