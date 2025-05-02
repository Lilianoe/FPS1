using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    private DamageEffect damageEffect;

    private void Awake()
    {
        damageEffect = GetComponent<DamageEffect>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Vous avez pris des dégâts, votre vie est à : " + health);

        UI.instance.healthSlider.value = health;
        UI.instance.healthText.text = "health: " + health + "/" + maxHealth;

        if (damageEffect != null)
        {
            StartCoroutine(damageEffect.TakeDamageEffect());
        }

        if (health <= 0)
        {
            Debug.Log("Vous êtes mort !");
            GetComponent<BaseRespawn>().Respawn();
            health = maxHealth;
        }
    }
}