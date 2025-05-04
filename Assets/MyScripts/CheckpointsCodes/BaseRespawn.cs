using UnityEngine;

public class BaseRespawn : MonoBehaviour
{
    private Vector3 respawnPosition = new Vector3(-4f, 1f, -1f); 
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        
        Debug.Log("Position de respawn initialisée à : " + respawnPosition);
    }

    private void Update()
    {
        
        if (transform.position.y < -10f)
        {
            Debug.Log("Le joueur est tombé en dessous de -10 sur l'axe Y. Téléportation...");
            Respawn();
        }
    }

    public void Respawn()
    {
        Debug.Log("Respawn appelé. Téléportation à : " + respawnPosition);

        if (_controller != null)
        {
            _controller.enabled = false; 
            transform.position = respawnPosition; 
            _controller.enabled = true; 
        }
        else
        {
            transform.position = respawnPosition; 
        }

        Debug.Log("Le joueur a été téléporté à la position : " + respawnPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Checkpoint"))
        {
            respawnPosition = other.transform.position; 
            Debug.Log("Checkpoint atteint ! Nouveau point de respawn défini à : " + respawnPosition);
        }
    }
}