using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Material damageMaterial;
    public GameObject spritePrefab;

    private Renderer rend;
    private Material originalMaterial;

    void Start()
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10f);
        }
    }

    public List<GameObject> spritePrefabs;

    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            // Select a random sprite prefab from the list
            int index = Random.Range(0, spritePrefabs.Count);
            GameObject selectedSpritePrefab = spritePrefabs[index];

            // Spawn the selected sprite at the enemy's position with a random rotation around the Z-axis, and rotate it by 90 degrees around the X-axis
            GameObject spriteObject = Instantiate(selectedSpritePrefab, transform.position, Quaternion.Euler(90f, 0f, Random.Range(0f, 360f)));

            // Destroy the enemy game object
            Destroy(transform.parent.gameObject);
        }
        else
        {
            // Change the material to the damage material
            rend.material = damageMaterial;

            // Call the ResetMaterial() function after a short delay to reset the material back to normal
            Invoke("ResetMaterial", 0.1f);
        }
    }



    void ResetMaterial()
    {
        // Reset the material back to the original material
        rend.material = originalMaterial;
    }

    public ScoreManager scoreManager;
    private void OnDestroy()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore();
        }
    }
}

