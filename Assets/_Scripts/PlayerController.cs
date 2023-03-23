using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Image[] healthImages; // An array of Image components to display the player's health

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(5f);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            GameOver();
        }

        UpdateHealthUI();
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
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