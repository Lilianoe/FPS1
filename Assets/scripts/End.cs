using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour charger des scènes
using UnityEngine.UI; // Nécessaire pour afficher du texte

public class End : MonoBehaviour
{
    public Text endText; // Référence au texte à afficher
    public string mainMenuSceneName = "MainMenu"; // Nom de la scène du menu principal

    private void Start()
    {
        if (endText != null)
        {
            endText.gameObject.SetActive(false); // Masquer le texte au début
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifier si c'est le joueur qui entre en collision
        {
            if (endText != null)
            {
                endText.gameObject.SetActive(true); // Afficher le texte
            }

            // Retourner au menu principal après 5 secondes
            Invoke("ReturnToMainMenu", 3f);
        }
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName); // Charger la scène du menu principal
    }
}