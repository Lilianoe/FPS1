using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int heal; // Quantité de vie à restaurer

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre en collision avec l'objet
        if (other.CompareTag("Player"))
        {
            // Récupère le script PlayerHealth sur le joueur
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(heal); // Redonne de la vie au joueur
                Debug.Log($"Le joueur a récupéré {heal} points de vie !");
            }

            // Détruit l'objet de soin
            Destroy(gameObject);
        }
    }
}