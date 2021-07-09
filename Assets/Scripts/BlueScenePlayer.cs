using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScenePlayer : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.Space;
    public float maxForce = 1000f;
    public float maxTorque = 1000f;

    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce)));
            rb.AddTorque(new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque)));
        }
    }
}
