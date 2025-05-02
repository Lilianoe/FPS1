using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera mycamera;
    [SerializeField] private Transform target;

    public void UpdateHealthBar(float _currentHealth, float MaxHealth)
    {
        slider.value = _currentHealth / MaxHealth;
    }
    void Update()
    {
        //transform.rotation = camera.transform.rotation;
    }
}
