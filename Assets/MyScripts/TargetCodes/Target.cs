using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public float damageToPlayer = 10f;
    public float attackInterval = 2f;
    public float attackRange = 5f; // Distance maximale pour attaquer le joueur

    private float attackTimer = 0f;
    private Transform playerTransform;

    private void Start()
    {
        // Trouve le joueur dans la scène
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player introuvable !");
        }
    }

    private void Update()
    {
        // Attaque contre notre perso
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            AttackPlayer();
            attackTimer = 0f;
        }
    }

    void AttackPlayer()
    {
        if (playerTransform != null)
        {
            // Vérifie si le joueur est dans la portée d'attaque
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            Debug.Log($"[{gameObject.name}] Distance au joueur : {distanceToPlayer}");

            if (distanceToPlayer <= attackRange)
            {
                PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage((int)damageToPlayer); // Convertit le float en int
                    Debug.Log($"[{gameObject.name}] Vous êtes attaqué par un ennemi !");
                }
            }
            else
            {
                Debug.Log($"[{gameObject.name}] Le joueur est hors de portée !");
            }
        }
    }
    // Méthode pour infliger des dégâts à l'ennemi
    public void TakeDamage(float amount)
{
    health -= amount; // Réduit la santé de l'ennemi
    Debug.Log($"Ennemi touché ! Santé restante : {health}");

    if (health <= 0)
    {
        Die();
    }
}

    void Die()
    {
        Debug.Log("Ennemi détruit !");
        Destroy(gameObject); // Détruit l'ennemi
    }
}