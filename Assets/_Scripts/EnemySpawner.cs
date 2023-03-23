using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

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
    public TMP_Text currentWaveText; // Reference to the UI Text object for displaying the current wave
    public TMP_Text enemiesRemainingText; // Reference to the UI Text object for displaying the enemies remaining
    public bool waveInProgress = false; // Whether a wave is currently in progress



    void Start()
    {
        timeUntilNextWave = timeBetweenWaves;
        waveInProgress = false;
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
        else
        {
            // Check if the current wave is in progress
            if (enemiesRemaining > 0)
            {
                waveInProgress = true;
            }
            else
            {
                spawningEnemies = false;
                waveInProgress = false;
            }
        }

    // Update the UI Text objects with the current wave and enemies remaining
    currentWaveText.text = "Wave: " + currentWave.ToString();
        enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString();
    }

    void SpawnEnemy()
    {
        // Pick a random spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        // Spawn the enemy at the chosen spawn point
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        // Decrement the number of enemies remaining
        enemiesRemaining--;
        // Set the wave in progress when an enemy is spawned
        waveInProgress = true;
        if (enemiesRemaining == 0)
        {
            // Stop spawning enemies when the wave is finished
            spawningEnemies = false;
        }
    }
}
