using UnityEngine;

public class Shootingligh : MonoBehaviour
{
    
    public GameObject ShootingLight; 

    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            ActivateShootingLight();
        }
    }

    void ActivateShootingLight()
    {
        
        if (ShootingLight != null)
        {
            Debug.Log("ShootingLight activated");
            ShootingLight.SetActive(true);

            
            Invoke("DisableShootingLight", 0.5f);
        }
    }

    void DisableShootingLight()
    {
        
        if (ShootingLight != null)
        {
            Debug.Log("ShootingLight deactivated");
            ShootingLight.SetActive(false);
        }
    }
}