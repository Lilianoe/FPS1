using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void Update()
    {
        
        if (SceneManager.GetActiveScene().name != "MainMenu") 
        {
            if (audioSource != null)
            {
                audioSource.Stop(); 
            }

            Destroy(gameObject); 
        }
    }
}
