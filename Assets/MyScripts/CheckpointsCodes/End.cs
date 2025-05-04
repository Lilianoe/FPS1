using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class End : MonoBehaviour
{
    public Text endText; 
    public string mainMenuSceneName = "MainMenu"; 

    private void Start()
    {
        if (endText != null)
        {
            endText.gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (endText != null)
            {
                endText.gameObject.SetActive(true); 
            }


            Invoke("ReturnToMainMenu", 2f);
        }
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName); 
    }
}