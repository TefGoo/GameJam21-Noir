using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int numOfEnemies = 10;

    private int waveNumber = 1;
    private bool isSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        if (!isSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        isSpawning = true;

        for (int i = 0; i < numOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GetNextSpawnPoint().position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f); // spawn enemies with a small delay
        }

        // Increase the number of enemies for the next wave
        if (waveNumber == 1)
        {
            numOfEnemies = 15;
        }
        else if (waveNumber == 2)
        {
            numOfEnemies = 25;
        }
        else if (waveNumber == 3)
        {
            numOfEnemies = 30;
        }
        else if (waveNumber == 4)
        {
            numOfEnemies = 50;
        }

        waveNumber++;

        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("EnemyBody").Length == 0); // wait for all enemies to be killed

        isSpawning = false;
    }

    private Transform GetNextSpawnPoint()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        return spawnPoint;
    }
}
