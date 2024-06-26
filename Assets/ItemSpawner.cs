using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab del ítem a spawnear
    public List<Transform> spawnPoints; // Lista de puntos de spawn
    public float cooldownTime = 10f; // Tiempo de cooldown en segundos

    private bool isSpawning = false; // Flag para controlar el cooldown

    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            if (!isSpawning)
            {
                foreach (Transform spawnPoint in spawnPoints)
                {
                    // Verificar si la posición está vacía
                    if (IsPositionEmpty(spawnPoint.position))
                    {
                        Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
                        isSpawning = true;
                        yield return new WaitForSeconds(cooldownTime);
                        isSpawning = false;
                    }
                }
            }
            yield return null;
        }
    }

    bool IsPositionEmpty(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        return colliders.Length == 0;
    }
}
