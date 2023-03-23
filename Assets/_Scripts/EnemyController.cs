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

    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            // Spawn a sprite at the enemy's position
            Instantiate(spritePrefab, transform.position, Quaternion.identity);

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

}
