using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float Countdown;
    void Start()
    {
        Invoke("DestroyMe",Countdown);
        
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
