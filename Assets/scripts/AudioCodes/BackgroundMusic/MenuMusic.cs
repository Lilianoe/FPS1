using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Source audio pour la musique de fond

    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Joue la musique de fond
        }
    }

    private void Update()
    {
        // Vérifie si la scène a changé
        if (SceneManager.GetActiveScene().name != "MainMenu") // Remplacez "Menu" par le nom exact de votre scène de menu
        {
            if (audioSource != null)
            {
                audioSource.Stop(); // Arrête la musique
            }

            Destroy(gameObject); // Détruit l'objet pour éviter qu'il persiste dans d'autres scènes
        }
    }
}
