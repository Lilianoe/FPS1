using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance; 
    public Slider healthSlider;
        public Text healthText; 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth; 
        }

        if (healthText != null)
        {
            healthText.text = $"Health: {currentHealth}/{maxHealth}"; 
        }
    }
}