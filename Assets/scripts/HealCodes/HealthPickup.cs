using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int heal;

    private void Ontrigger(Collider other)
    {
        if (other.tag == "Player")
        { 
            
            
            Destroy(gameObject);
        }
    }
}
