using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Sprite[] healthSprites; // An array of sprites to display the player's health

    public Image[] healthImages; // An array of Image components to display the player's health

    public Slider healthBarSlider; // The slider component to display the player's health as a bar

    public GameObject gameOverMenu; // Assign the UI menu object in the inspector

    public GameObject GameMenu; // Assign the UI menu object in the inspector

    public AudioSource backgroundMusic; // Assign the background music audio source in the inspector
    public AudioSource gameOverSound; // Assign the Game Over sound audio source in the inspector


    private void Start()
    {
        currentHealth = maxHealth;

        // Set the maximum value of the health bar slider to the player's maximum health
        healthBarSlider.maxValue = maxHealth;

        // Set the initial value of the health bar slider to the player's current health
        healthBarSlider.value = currentHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(10f);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            GameOver();
        }

        // Update the health bar slider value to reflect the player's current health
        healthBarSlider.value = currentHealth;

        UpdateHealthUI();
    }

    void GameOver()
    {
        gameOverMenu.SetActive(true); // Activate the Game Over menu
        GameMenu.SetActive(false); // Deactivate the Pause menu                                 
        Time.timeScale = 0f; // Stop game time

        // Mute the background music and play the Game Over sound
        backgroundMusic.mute = true;
        gameOverSound.Play();
    }


    void UpdateHealthUI()
    {
        // Determine which health image to display based on the current health value
        if (currentHealth >= 100f)
        {
            SetActiveImage(0);
        }
        else if (currentHealth >= 75f)
        {
            SetActiveImage(1);
        }
        else if (currentHealth >= 50f)
        {
            SetActiveImage(2);
        }
        else if (currentHealth >= 25f)
        {
            SetActiveImage(3);
        }
        else
        {
            SetActiveImage(4);
        }
    }

    void SetActiveImage(int index)
    {
        // Disable all health images except the one at the specified index
        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].gameObject.SetActive(i == index);
        }
    }
}
