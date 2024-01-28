using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int waypointIndex = 0;
    [SerializeField] private float speed = 3f;

    // Update is called once per frame
    void Update() // it is a loop
    {
        // if current position is past current waypoint, increment waypoint index
        GameObject currentWaypoint = waypoints[waypointIndex];

        if(Vector2.Distance(transform.position, currentWaypoint.transform.position) < 0.1f)
        {
            waypointIndex++;
            Debug.Log("Moving to next waypoint!");
            if(waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
                Debug.Log("Resetting waypoint!");
            }
            currentWaypoint = waypoints[waypointIndex];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.transform.position, speed * Time.deltaTime);
        }
        // otherwise move towards
    }
}
