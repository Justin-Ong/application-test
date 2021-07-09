using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSceneCamera : MonoBehaviour
{
    public GameObject player;

    private Transform playerTransform;
    private Vector3 cameraOffset;

    void Start()
    {
        playerTransform = player.transform;
        cameraOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + cameraOffset;
    }
}
