using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    public Image HealthBar;
    public AudioSource AudioSource;
    public int StartHealth;
    private int _currentHealth;
    private int MaxHealth;

    [SerializeField] FloatingHealthBar healthbar;
    
    private void Start()
    {
        _currentHealth = StartHealth;
    }

    public void Damage(int value)
    {
        _currentHealth -= value;
        if (_currentHealth == 0)
        {
            AudioSource.Play();
            //Destroy(gameObject);
        }
    }

}