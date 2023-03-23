using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullet : MonoBehaviour
{
    public float timeToDestroy = 3f;
    private bool isDestroyed = false;

    private void Start()
    {
        // Ignore collisions between this object's layer and the "Enemy" layer
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);

        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(timeToDestroy);

        if (!isDestroyed)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Restore collisions between this object's layer and the "Enemy" layer
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Bullet"), false);

        isDestroyed = true;
    }
}
