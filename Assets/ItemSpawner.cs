using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> itemPrefabs; // Lista de prefabs de ítems a spawnear
    public List<Transform> spawnPoints; // Lista de puntos de spawn
    public float cooldownTime = 10f; // Tiempo de cooldown en segundos

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            // Esperar hasta que todos los puntos de spawn estén vacíos
            while (!AllSpawnPointsEmpty())
            {
                yield return null;
            }

            // Spawnear ítems en todos los puntos de spawn
            foreach (Transform spawnPoint in spawnPoints)
            {
                // Seleccionar un ítem al azar de la lista
                int randomIndex = Random.Range(0, itemPrefabs.Count);
                GameObject itemPrefab = itemPrefabs[randomIndex];

                // Instanciar el ítem en la posición de spawn
                Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
            }

            // Esperar el cooldown antes de comenzar el siguiente ciclo de spawn
            yield return new WaitForSeconds(cooldownTime);
        }
    }

    bool AllSpawnPointsEmpty()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (!IsPositionEmpty(spawnPoint.position))
            {
                return false;
            }
        }
        return true;
    }

    bool IsPositionEmpty(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        return colliders.Length == 0;
    }
}