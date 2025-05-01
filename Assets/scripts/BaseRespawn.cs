using UnityEngine;

public class BaseRespawn : MonoBehaviour
{
    private Vector3 respawnPosition = new Vector3(-4f, 1f, -1f); // Coordonnées fixes pour le premier respawn
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        // Initialise la position de respawn à des coordonnées fixes
        Debug.Log("Position de respawn initialisée à : " + respawnPosition);
    }

    private void Update()
    {
        // Vérifie si le joueur est tombé en dessous de -10 sur l'axe Y
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
            _controller.enabled = false; // Désactive le CharacterController pour éviter les conflits
            transform.position = respawnPosition; // Téléporte le joueur à la position de respawn
            _controller.enabled = true; // Réactive le CharacterController
        }
        else
        {
            transform.position = respawnPosition; // Si pas de CharacterController, déplace directement
        }

        Debug.Log("Le joueur a été téléporté à la position : " + respawnPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur touche un checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            respawnPosition = other.transform.position; // Met à jour la position de respawn
            Debug.Log("Checkpoint atteint ! Nouveau point de respawn défini à : " + respawnPosition);
        }
    }
}