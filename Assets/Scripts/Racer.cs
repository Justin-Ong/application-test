using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    [Header("Duration of pathing")]
    public float maxDuration = 20f;
    public float minDuration = 15f;

    [Header("Path")]
    public GameObject path;

    private float duration;
    private List<Vector3> waypoints = new List<Vector3>();

    void Start()
    {
        duration = Random.Range(minDuration, maxDuration);
        waypoints.Add(transform.position);
        foreach (Transform point in path.transform) {
            waypoints.Add(point.position);
        }
        Tween t = transform.DOPath(waypoints.ToArray(), duration, PathType.Linear).SetOptions(true).SetLookAt(0.01f).SetEase(Ease.Linear);
    }
}
