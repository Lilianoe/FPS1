using UnityEngine;

public class GunController : MonoBehaviour
{
    public float power = 1f;
    public Transform raycastorigin;
    public GameObject bulletprefab;

    // Effets
    public GameObject ShootingLight; 
    public GameObject Impact; 
    public AudioClip shootingSound; 
    private AudioSource audioSource; 

    // Tir
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        
        if (PauseMenu.isPaused)
        {
            return; 
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        if (shootingSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        
        if (ShootingLight != null)
        {
            ShootingLight.SetActive(true); 
            Invoke("DisableShootingLight", 0.7f); 
        }

        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            
            if (Impact != null)
            {
                GameObject impactGO = Instantiate(Impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f); 
            }
        }
        else
        {
            Debug.Log("No hit detected.");
        }
    }

    void DisableShootingLight()
    {
        
        if (ShootingLight != null)
        {
            ShootingLight.SetActive(false);
        }
    }
}