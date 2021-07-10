using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    [Header("Speed")]
    public float maxSpeed = 10f;
    public float minSpeed = 5f;

    [Header("Path")]
    public GameObject path;
    public float distanceToRegisterWaypoint = 1f;

    private float speed;
    private List<Vector3> waypoints = new List<Vector3>();
    private int numWaypoints;
    private int currWaypoint;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        foreach (Transform point in path.transform) {
            waypoints.Add(point.position);
        }
        numWaypoints = waypoints.Count - 1;
    }

    void Update()
    {
        Vector3 direction = waypoints[currWaypoint] - transform.position;
        if (direction.magnitude < distanceToRegisterWaypoint) {
            UpdateWaypoint();
        }
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void UpdateWaypoint()
    {
        if (currWaypoint < numWaypoints)
        {
            currWaypoint++;
        }
        else
        {
            currWaypoint = 0;
        }
    }
}
