using UnityEngine;

public class CheckpointPlateform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Met à jour la position du dernier checkpoint
                playerController.lastCheckpointPosition = transform.position;

                // Optionnel : Affiche un message dans la console
                Debug.Log("Checkpoint atteint ! Nouveau point de spawn défini à : " + transform.position);
            }
        }
    }
}