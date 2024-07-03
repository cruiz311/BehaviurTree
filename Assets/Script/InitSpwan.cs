using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InitSpwan : MonoBehaviour
{
    public GameObject policia;
    public GameObject civil;
    public GameObject zombie;

    void Start()
    {
        // Instanciar policia
        for (int i = 0; i < GameManager.Instance.numerosPolicia; i++)
        {

            Vector3 spawnPosition;
            if (GetRandomPosition(out spawnPosition))
            {
                Instantiate(policia, spawnPosition, Quaternion.identity);
            }
        }

        // Instanciar civil
        for (int i = 0; i < GameManager.Instance.numerosCivil; i++)
        {
            Vector3 spawnPosition;
            if (GetRandomPosition(out spawnPosition))
            {
                Instantiate(civil, spawnPosition, Quaternion.identity);
            }
        }

        // Instanciar zombie
        for (int i = 0; i < GameManager.Instance.numerosZombie; i++)
        {
            Vector3 spawnPosition;
            if (GetRandomPosition(out spawnPosition))
            {
                Instantiate(zombie, spawnPosition, Quaternion.identity);
            }
        }
    }

    bool GetRandomPosition(out Vector3 result)
    {
        int maxAttempts = 30;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * 2f;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        // Si no se encuentra una posición válida después de varios intentos, devuelve la posición más cercana en el NavMesh
        NavMesh.SamplePosition(transform.position, out NavMeshHit closestHit, Mathf.Infinity, NavMesh.AllAreas);
        result = closestHit.position;
        return true;
    }

}
