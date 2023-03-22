using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullet : MonoBehaviour
{
    public float timeToDestroy = 5f;

    private bool isDestroyed = false;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(timeToDestroy);

        if (!isDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
