using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (pauseMenu.activeSelf) 
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame(); 
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}

