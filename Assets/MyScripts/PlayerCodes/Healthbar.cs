using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthslider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthslider != null && PlayerHealth.instance != null)
        {
            healthslider.value = PlayerHealth.instance.currentHealth / PlayerHealth.instance.maxHealth;
        }
    }
}
