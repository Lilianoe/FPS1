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
                
                playerController.lastCheckpointPosition = transform.position;

            }
        }
    }
}