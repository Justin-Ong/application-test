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
    private bool isReturning;
    private bool finishedRace;

    void Start()
    {
        speed = 0f; // Speed 0 until user starts race
        finishedRace = true;
        isReturning = true;
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
        Vector3 direction = waypoints[currWaypoint] - transform.position;
        if (!finishedRace) {
            if (direction.magnitude < distanceToRegisterWaypoint)
            {
                if (isReturning && finishedRace)
                {
                    speed = 0f;
                }
                else
                {
                    UpdateWaypoint();
                    RandomiseSpeed();
                }
            }
            transform.position += direction.normalized * speed * Time.deltaTime;
            transform.LookAt(waypoints[currWaypoint]);
        }
    }

    void UpdateWaypoint()
    {
        if (currWaypoint < numWaypoints)
        {
            currWaypoint++;
        }
        else
        {
            if (isReturning)
            {
                finishedRace = true;
            }
            isReturning = true;
            waypoints.Reverse();
            currWaypoint = 0;
        }
    }

    void RandomiseSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    public bool IsFinished()
    {
        return finishedRace;
    }

    public void StartRace()
    {
        finishedRace = false;
        isReturning = false;
        RandomiseSpeed();
        currWaypoint = 0;
    }
}
