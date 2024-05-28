using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinPanel2: MonoBehaviour
{
    public GameObject winpanel;
  public void OnnextLevel()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene("Level 3");
    }
    public void OnMainMneu()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene("Main Menu", 0);
    }

    public void Quit()
    {
        winpanel.SetActive(false);
        Debug.Log("application quit ");
        Application.Quit();
    }
}
