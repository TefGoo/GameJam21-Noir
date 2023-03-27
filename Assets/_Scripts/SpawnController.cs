using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{

    public GameObject prefabToSpawn;
    public Transform[] spawnPoints;
    public float spawnInterval = 15f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(prefabToSpawn, spawnPoints[spawnIndex].position, Quaternion.identity);
            timeSinceLastSpawn = 0f;
        }
    }
}
