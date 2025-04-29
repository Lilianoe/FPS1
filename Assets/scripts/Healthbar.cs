using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;
    
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }
}
