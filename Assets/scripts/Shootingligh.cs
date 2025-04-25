using UnityEngine;

public class Shootingligh : MonoBehaviour
{
    // Effets
    public GameObject ShootingLight; // Lumière qui s'active lors du tir

    private void Update()
    {
        // Détecter le clic gauche pour tirer
        if (Input.GetButtonDown("Fire1"))
        {
            ActivateShootingLight();
        }
    }

    void ActivateShootingLight()
    {
        // Activer l'effet de lumière
        if (ShootingLight != null)
        {
            Debug.Log("ShootingLight activated");
            ShootingLight.SetActive(true);

            // Désactiver la lumière après un court délai
            Invoke("DisableShootingLight", 0.5f);
        }
    }

    void DisableShootingLight()
    {
        // Désactiver la lumière
        if (ShootingLight != null)
        {
            Debug.Log("ShootingLight deactivated");
            ShootingLight.SetActive(false);
        }
    }
}