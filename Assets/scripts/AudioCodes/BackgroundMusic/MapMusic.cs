using UnityEngine;

public class MapMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Source audio pour la musique de fond
    private bool hasStarted = false; // Empêche de jouer la musique plusieurs fois

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre dans le checkpoint
        if (other.CompareTag("Player") && !hasStarted)
        {
            hasStarted = true; // Empêche de rejouer la musique
            if (audioSource != null)
            {
                audioSource.loop = true; // Assure que la musique se répète en boucle
                audioSource.Play(); // Joue la musique de fond
                Debug.Log("Musique de fond déclenchée !");
            }
            else
            {
                Debug.LogError("AudioSource non assigné au script MapMusic !");
            }
        }
    }
}
