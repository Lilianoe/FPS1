using UnityEngine;

public class GunController : MonoBehaviour
{
    public float power = 1f;
    public Transform raycastorigin;
    public GameObject bulletprefab;

    // Effets
    public GameObject ShootingLight; // Lumière qui s'active lors du tir
    public GameObject Impact; // Impact sur la surface touchée
    public AudioClip shootingSound; // Son du tir
    private AudioSource audioSource; // Composant AudioSource

    // Tir
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

    private void Start()
    {
        // Récupérer ou ajouter un AudioSource au GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Détecter le clic gauche pour tirer
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Jouer le son du tir
        if (shootingSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        // Activer l'effet de lumière (ShootingLight)
        if (ShootingLight != null)
        {
            ShootingLight.SetActive(true); // Activer la lumière
            Invoke("DisableShootingLight", 0.7f); // Désactiver après 0.05 seconde
        }

        // Effectuer le raycast pour détecter les impacts
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Appliquer des dégâts si la cible a un script Target
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // Instancier l'effet d'impact
            if (Impact != null)
            {
                GameObject impactGO = Instantiate(Impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f); // Détruire l'impact après 1 seconde
            }
        }
        else
        {
            Debug.Log("No hit detected.");
        }
    }

    void DisableShootingLight()
    {
        // Désactiver la lumière
        if (ShootingLight != null)
        {
            ShootingLight.SetActive(false);
        }
    }
}