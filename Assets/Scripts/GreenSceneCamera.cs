using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSceneCamera : MonoBehaviour
{
    public float elevation;
    public float cameraDistance = 1f;
    public List<GameObject> racers = new List<GameObject>();

    private List<Transform> racerTransforms = new List<Transform>();

    void Start()
    {
        foreach (GameObject racer in racers) {
            racerTransforms.Add(racer.transform);
        }
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
        center /= racers.Count;
        float objectSize = Mathf.Max(maxX - minX, maxY - minY, maxZ - minZ);
        float cameraView = 2.0f * Mathf.Tan(0.5f * Mathf.Deg2Rad * Camera.main.fieldOfView);
        float distance = cameraDistance * objectSize / cameraView;
        distance += 0.5f * objectSize;
        Camera.main.transform.position = center - distance * Camera.main.transform.forward;
        //Camera.main.transform.LookAt(center);
    }
}
