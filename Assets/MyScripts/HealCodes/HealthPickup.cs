using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int heal; 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(heal); 
                Debug.Log($"Le joueur a récupéré {heal} points de vie !");
            }

           
            Destroy(gameObject);
        }
    }
}