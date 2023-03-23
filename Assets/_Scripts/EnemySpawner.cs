using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab; // Enemy prefab to spawn
    public float spawnInterval = 3f; // Time between spawns
    public int enemiesPerWave = 10; // Number of enemies to spawn in each wave
    public float timeBetweenWaves = 10f; // Time between waves
    public Transform[] spawnPoints; // Array of spawn points for enemies
    public int currentWave = 0; // Current wave number
    public int enemiesRemaining; // Number of enemies remaining in the current wave
    public float timeUntilNextWave; // Time until the next wave begins
    public bool spawningEnemies = false; // Whether enemies are currently being spawned

    void Start()
    {
        timeUntilNextWave = timeBetweenWaves;
    }

    void Update()
    {
        if (!spawningEnemies)
        {
            if (enemiesRemaining == 0)
            {
                // Start a new wave
                currentWave++;
                enemiesRemaining = enemiesPerWave * currentWave;
                timeUntilNextWave = timeBetweenWaves;
            }
            else
            {
                // Wait for the current wave to end
                timeUntilNextWave -= Time.deltaTime;
                if (timeUntilNextWave <= 0f)
                {
                    SpawnEnemy();
                    timeUntilNextWave = spawnInterval;
                }
            }
        }
    }

    void SpawnEnemy()
    {
        // Pick a random spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        // Spawn the enemy at the chosen spawn point
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        // Decrement the number of enemies remaining
        enemiesRemaining--;
        if (enemiesRemaining == 0)
        {
            // Stop spawning enemies when the wave is finished
            spawningEnemies = false;
        }
    }
}
