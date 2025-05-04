using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance; // Instance statique pour un accès global
    public Slider healthSlider; // Slider pour la barre de vie
    public Text healthText; // Texte pour afficher la santé

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Initialise l'instance statique
        }
        else
        {
            Destroy(gameObject); // Empêche les doublons
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth; // Met à jour la valeur du Slider
        }

        if (healthText != null)
        {
            healthText.text = $"Health: {currentHealth}/{maxHealth}"; // Met à jour le texte
        }
    }
}