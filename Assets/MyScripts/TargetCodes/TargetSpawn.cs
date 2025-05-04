using UnityEngine;
using System.Collections.Generic;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Tableau de préfabriqués d'ennemis
    [SerializeField] private Transform[] spawnPoints; // Tableau de points d'apparition
    private bool hasSpawned = false; // Empêche de réapparaître plusieurs fois

    private void Start()
    {
        // Désactive tous les ennemis originaux au démarrage
        foreach (GameObject enemy in enemyPrefabs)
        {
            enemy.SetActive(false); // Désactive les GameObjects originaux
        }
    }

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

            // Téléporte chaque ennemi à son point d'apparition
            for (int i = 0; i < enemyPrefabs.Length; i++)
            {
                enemyPrefabs[i].transform.position = spawnPoints[i].position; // Téléporte l'ennemi
                enemyPrefabs[i].transform.rotation = spawnPoints[i].rotation; // Met à jour la rotation
                enemyPrefabs[i].SetActive(true); // Active l'ennemi
                Debug.Log($"Ennemi {i + 1} téléporté à {spawnPoints[i].position}");
            }
        }
    }
}