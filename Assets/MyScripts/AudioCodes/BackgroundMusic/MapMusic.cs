using UnityEngine;

public class MapMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; 
    private bool hasStarted = false; 

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player") && !hasStarted)
        {
            hasStarted = true; 
            if (audioSource != null)
            {
                audioSource.loop = true; 
                audioSource.Play(); 
                Debug.Log("Musique de fond déclenchée !");
            }
            else
            {
                Debug.LogError("AudioSource non assigné au script MapMusic !");
            }
        }
    }
}
