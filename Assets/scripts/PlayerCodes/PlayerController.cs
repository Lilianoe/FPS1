using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float rotationSpeed = 20f;
    public float jumpHeight = 1f;
    public GameObject playerHead;
    private float gravityValue = -7f;
    public float health = 100f;
    public float maxHealth = 100f;
    public Vector3 lastCheckpointPosition = new Vector3(-4, 1, 0); 

    private CharacterController _controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private DamageEffect damageEffect;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        health = maxHealth;

    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        damageEffect = GetComponent<DamageEffect>();
    }

    private void Update()
    {
        // Détection du sol
        groundedPlayer = _controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }

        // Déplacement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move) * playerSpeed;
        _controller.Move(move * Time.deltaTime);

        // Rotation
        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        transform.Rotate(rotation * Time.deltaTime, Space.Self);

        // Camera
        Vector3 rotationCamera = new Vector3(-Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0);
        playerHead.transform.Rotate(rotationCamera * Time.deltaTime, Space.Self);

        // Jump
        if (groundedPlayer && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Gravite
        playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);

        health = Mathf.Clamp(health, 0, maxHealth);

        // Met à jour la barre de vie via le script UI
        if (UI.instance != null)
        {
            UI.instance.UpdateHealthBar(health, maxHealth);
        }

        // Respawn si nécessaire
        if (health <= 0)
        {
            Respawn();
        }
    }

        private void Respawn()
    {
        transform.position = lastCheckpointPosition; // Replace le joueur au dernier checkpoint
        health = maxHealth; // Réinitialise la santé

        // Met à jour la barre de vie via le script UI
        if (UI.instance != null)
        {
            UI.instance.UpdateHealthBar(health, maxHealth);
        }

        Debug.Log("Le joueur a respawné !");
    }

    private void UpdateHealthUI()
    {
        if (UI.instance != null)
        {
            UI.instance.healthSlider.value = health;
            UI.instance.healthText.text = "health: " + health + "/" + maxHealth;
        }
        else
        {
            Debug.LogError("UI.instance est introuvable !");
        }
        if (UI.instance != null)
        {
            UI.instance.UpdateHealthBar(health, maxHealth);
        }
        else
        {
            Debug.LogError("UI.instance est introuvable !");
        }
    }
}

