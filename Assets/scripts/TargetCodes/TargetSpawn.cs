using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Tableau de préfabriqués d'ennemis
    [SerializeField] private Transform[] spawnPoints; // Tableau de points d'apparition
    private bool hasSpawned = false; // Empêche de réapparaître plusieurs fois

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre dans la zone de déclenchement
        if (other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true; // Empêche de réapparaître plusieurs fois

            // Vérifie que les tableaux sont valides
            if (enemyPrefabs.Length != spawnPoints.Length)
            {
                Debug.LogError("Le nombre de préfabriqués d'ennemis ne correspond pas au nombre de points d'apparition !");
                return;
            }

            // Instancie chaque ennemi à son point d'apparition
            for (int i = 0; i < enemyPrefabs.Length; i++)
            {
                Instantiate(enemyPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
                Debug.Log($"Ennemi {i + 1} apparu !");
            }
        }
    }
}
