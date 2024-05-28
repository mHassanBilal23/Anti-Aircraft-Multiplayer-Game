using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSelection : MonoBehaviour
{

    public void OnShaheenHawk()
    {
       SceneManager.LoadScene("Badr-313");
    }
    public void OnBadr313()
    {
        SceneManager.LoadScene("Shaheen Hawk");
    }
    public void OnMainMneu1()
    {
      
        SceneManager.LoadScene("Main Menu");
    }
}
