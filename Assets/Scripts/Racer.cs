using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    [Header("Speed")]
    public float maxSpeed = 10f;
    public float minSpeed = 5f;

    [Header("Pathing")]
    public List<Vector3> path;
    public float distanceToRegisterWaypoint = 0.1f;

    private float speed;
    private List<Vector3> waypoints = new List<Vector3>();
    private int numWaypoints;
    private int currWaypoint;
    private bool finishedRace;
    private bool firstRace;

    void Start()
    {
        speed = 0f; // Speed 0 until user starts race
        firstRace = true;
        finishedRace = false;
        currWaypoint = 0;
        waypoints.Add(transform.position);
        foreach (Vector3 point in path)
        {
            waypoints.Add(point);
        }
        numWaypoints = waypoints.Count - 1;
    }

    void Update()
    {
        if (!finishedRace)
        {
            Vector3 direction = waypoints[currWaypoint] - transform.position;
            if (direction.magnitude < distanceToRegisterWaypoint)
            {
                UpdateWaypoint();
                RandomiseSpeed();
            }
            transform.position += direction.normalized * speed * Time.deltaTime;
            transform.LookAt(waypoints[currWaypoint]);
        }
    }

    public void Stop()
    {
        speed = 0;
        finishedRace = true;
    }

    void UpdateWaypoint()
    {
        if (currWaypoint < numWaypoints)
        {
            currWaypoint++;
        }
        else
        {
            waypoints.Reverse();
            currWaypoint = 0;
            firstRace = false;
        }
    }

    void RandomiseSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    public void StartRace()
    {
        if (!firstRace)
        {
            waypoints.Reverse();
        }
        finishedRace = false;
        RandomiseSpeed();
        currWaypoint = 0;
    }
}
