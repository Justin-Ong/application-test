using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSceneCamera : MonoBehaviour
{
    public float minCameraDistance = 20f;
    public float maxZoomSpeed = 1f;

    private List<Transform> racerTransforms = new List<Transform>();

    void Start()
    {
        racerTransforms = GreenSceneController.racerTransforms;
    }

    void LateUpdate()
    {
        Vector3 center = Vector3.zero;
        float maxX = -100f, maxZ = -100f, minX = 100f, minZ = 100f;
        foreach (Transform racerTransform in racerTransforms)
        {
            center.x += racerTransform.position.x;
            center.z += racerTransform.position.z;

            if (racerTransform.position.x > maxX) {
                maxX = racerTransform.position.x;
            }
            if (racerTransform.position.z > maxZ) {
                maxZ = racerTransform.position.z;
            }
            if (minX > racerTransform.position.x)
            {
                minX = racerTransform.position.x;
            }
            if (minZ > racerTransform.position.z)
            {
                minZ = racerTransform.position.z;
            }
        }
        center /= racerTransforms.Count;
        float viewArea = Mathf.Max(maxX - minX, maxZ - minZ);
        float distance = viewArea / Mathf.Sin(Camera.main.fieldOfView * Mathf.Deg2Rad * 0.5f);
        distance *= 0.6f;   // Constrain zoom out, 0.6 seems to work
        if (distance < minCameraDistance)
        {
            distance = minCameraDistance;
        }
        transform.position = Vector3.Lerp(transform.position, center + Vector3.up * distance, maxZoomSpeed);
    }
}
