using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour

{
    public float health = 100f;
    public float damageToPlayer = 10f; 
    public float attackInterval = 2f; 
    public int StartHealth = 100;
    private int _currentHealth;
    private int MaxHealth = 100;

    private float attackTimer = 0f;
    [SerializeField] FloatingHealthBar healthbar;
    
    private void Awake()
    {
        healthbar = GetComponentInChildren<FloatingHealthBar>();
    }
    
    private void Start()
    {
        _currentHealth = StartHealth;
        healthbar.UpdateHealthBar(health, MaxHealth);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthbar.UpdateHealthBar(health, MaxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void HealPlayer(int heal)
    {
        _currentHealth += heal;

        if (_currentHealth > MaxHealth)
        {
            _currentHealth = MaxHealth;
        }
        UI.instance.healthSlider.value = _currentHealth;
        UI.instance.healthText.text = "HEALTH"+_currentHealth + "/" + MaxHealth;
    }

    private void Update()
    {
        //attaque contre notre perso
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            AttackPlayer();
            attackTimer = 0f;
        }
    }

    void AttackPlayer()
{
    PlayerController player = Object.FindAnyObjectByType<PlayerController>();
    if (player != null)
    {
        player.TakeDamage(damageToPlayer); //inflige les degats
        Debug.Log("Vous etes attaqué par un ennemis");
    }
}
}