using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSceneCamera : MonoBehaviour
{
    public float elevation;
    public float minCameraDistance = 1f;

    private List<Transform> racerTransforms = new List<Transform>();
    private int numRacers;

    void Start()
    {
        racerTransforms = GreenSceneController.racerTransforms;
        numRacers = racerTransforms.Count;
    }

    void LateUpdate()
    {
        Vector3 center = Vector3.zero;
        float maxX = -100f, maxY = -100f, maxZ = -100f, minX = 100f, minY = 100f, minZ = 100f;
        foreach (Transform racerTransform in racerTransforms)
        {
            center.x += racerTransform.position.x;
            center.y += racerTransform.position.y;
            center.z += racerTransform.position.z;

            if (racerTransform.position.x > maxX) {
                maxX = racerTransform.position.x;
            }
            if (racerTransform.position.y > maxY) {
                maxY = racerTransform.position.y;
            }
            if (racerTransform.position.z > maxZ) {
                maxZ = racerTransform.position.z;
            }
            if (minX > racerTransform.position.x)
            {
                minX = racerTransform.position.x;
            }
            if (minY > racerTransform.position.y)
            {
                minY = racerTransform.position.y;
            }
            if (minZ > racerTransform.position.z)
            {
                minZ = racerTransform.position.z;
            }
        }
        center /= numRacers;
        float viewArea = Mathf.Max(maxX - minX, maxY - minY, maxZ - minZ);
        float distance = viewArea / Mathf.Sin(Camera.main.fieldOfView * Mathf.Deg2Rad * 0.5f);
        distance *= 0.6f;
        if (distance < minCameraDistance)
        {
            distance = minCameraDistance;
        }
        Camera.main.transform.position = center;
        Camera.main.transform.position += new Vector3(0, distance, 0);
    }
}
