using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y));
        Vector3 lookDir = mousePos - transform.position;
        lookDir.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360f);
    }

    void Shoot()
    {
        // Instantiate a new bullet at the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Get the direction the player is facing (the direction of the mouse)
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bullet.transform.position;
        direction.y = 0;

        // Set the velocity of the bullet to be in the direction the player is facing
        bullet.GetComponent<Rigidbody>().velocity = direction.normalized * -50f;

        // Set the bullet tag to "Bullet"
        bullet.tag = "Bullet";
    }

}
