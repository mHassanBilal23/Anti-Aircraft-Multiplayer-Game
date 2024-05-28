using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;
public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time;


    void Start()
    {
       AnimateBar();
       Invoke("LoadGameplayScene", 5f);
    }
   
    // Updation for animation in Scene

    public void AnimateBar()
    {

        LeanTween.scaleX(bar, 1, time);
 
    }
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Level Selection");
    }
}
