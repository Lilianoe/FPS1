using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vie maximale du joueur
    public int currentHealth; // Vie actuelle du joueur

    private void Start()
    {
        currentHealth = maxHealth; // Initialise la vie du joueur
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // Ajoute la quantité de soin
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Empêche de dépasser la vie maximale
        }

        Debug.Log($"Vie actuelle du joueur : {currentHealth}/{maxHealth}");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Réduit la vie du joueur
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Le joueur est mort !");
            // Ajoutez ici la logique pour gérer la mort du joueur
        }
    }
}