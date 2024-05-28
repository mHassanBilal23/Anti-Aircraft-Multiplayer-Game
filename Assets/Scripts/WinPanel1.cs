using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinPanel1: MonoBehaviour
{
    public GameObject winpanel1;
  public void OnnextLevel1()
    {
        winpanel1.SetActive(false);
        SceneManager.LoadScene("Level 2");
    }
    public void OnMainMneu1()
    {
        winpanel1.SetActive(false);
        SceneManager.LoadScene("Main Menu", 0);
    }

    public void Quit1()
    {
        winpanel1.SetActive(false);
        Debug.Log("application quit ");
        Application.Quit();
    }
}
