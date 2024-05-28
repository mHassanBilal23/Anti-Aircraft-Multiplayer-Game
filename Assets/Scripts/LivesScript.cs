using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour
{
    public int lives = 5;
    public Text livesText;
    public GameObject LostPanel;


    private void Start()
    {
        InitializeUI();
        UpdateLivesText();
    }

   
    private void InitializeUI()
    {
        
        if (livesText == null)
        {
            livesText = GetComponent<Text>();
        }

        
        if (livesText == null)
        {
            Debug.LogError("Lives Text is not assigned to the script or found on the GameObject.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("missile"))
        {
            lives--;



            if (lives <= 0)
            {
               LostPanel.SetActive(true);
                Time.timeScale = 0f;
            }

            UpdateLivesText();
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}

