using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints; // Lista de puntos de spawn para los �tems
    public List<Item> items; // Lista de �tems que pueden ser instanciados
    public List<Transform> availableSpawnPoints;
    private void Start()
    {
        SpawnItems();
    }
    private void Update()
    {
        //SpawnItems();
    }
    private void SpawnItems()
    {
        foreach (Item item in items)
        {
            // Seleccionar un punto de spawn aleatorio que no est� ocupado por otro �tem
            Transform spawnPoint = GetRandomSpawnPoint();

            // Instanciar el �tem en el punto de spawn seleccionado
            Instantiate(item, spawnPoint.position, Quaternion.identity);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // Lista para almacenar los puntos de spawn disponibles
        //availableSpawnPoints = new List<Transform>();

        // Iterar sobre todos los puntos de spawn
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Verificar si hay alg�n �tem en este punto de spawn
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 0.1f);
            if (colliders.Length == 0)
            {
                // Si no hay ning�n �tem en este punto de spawn, agregarlo a la lista de puntos de spawn disponibles
                availableSpawnPoints.Add(spawnPoint);
            }
        }

        // Si hay puntos de spawn disponibles, seleccionar uno aleatoriamente; de lo contrario, devolver null
        return availableSpawnPoints.Count > 0 ? availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)] : null;
    }
}

