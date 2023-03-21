using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float timeToDestroy = 5f;

    private bool isDestroyed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBody" && !isDestroyed)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(timeToDestroy);

        if (!isDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
