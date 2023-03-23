using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public int numEnemiesPerRound = 10;
    public float spawnInterval = 1f;
    public Transform[] spawnPoints;
    public int numRounds = 5;

    private int currentRound = 0;
    private int numEnemiesRemaining = 0;

    private void Start()
    {
        StartNewRound();
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numEnemiesPerRound; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            numEnemiesRemaining++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        if (numEnemiesRemaining == 0)
        {
            StartCoroutine(StartNextRound());
        }
    }

    private IEnumerator StartNextRound()
    {
        currentRound++;
        if (currentRound > numRounds)
        {
            SceneManager.LoadScene("Victory");
        }
        else
        {
            StartNewRound();
        }
        yield return null;
    }

    private void StartNewRound()
    {
        numEnemiesRemaining = 0;
        StartCoroutine(SpawnEnemies());
    }
}
