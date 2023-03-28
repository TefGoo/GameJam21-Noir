using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWayponiIndex = 0;

    [SerializeField] float speed = 1;

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWayponiIndex].transform.position) >= .1f)
        {
        }
        else
        {
            currentWayponiIndex++;
            if (currentWayponiIndex >= waypoints.Length)
                currentWayponiIndex = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayponiIndex].transform.position, speed * Time.deltaTime);  
    }
}
