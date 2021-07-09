using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSceneCrateSpawner : MonoBehaviour
{
    [Header("Crate Spawning")]
    public GameObject cratePrefab;
    public int numSpawnedCrates = 20;
    public GameObject floor;
    public float edgeBuffer = 0.5f;

    void Start()
    {
        Vector3 floorScale = floor.GetComponent<Renderer>().bounds.size;

        // Assuming the floor is symmetrical and has no holes
        float minXBound = -1 * floorScale.x / 2;
        float maxXBound = floorScale.x / 2;
        float minZBound = -1 * floorScale.z / 2;
        float maxZBound = floorScale.z / 2;

        Vector3 randomPos;
        for (int i = 0; i < numSpawnedCrates; i++)
        {
            randomPos = new Vector3(Random.Range(minXBound + edgeBuffer, maxXBound - edgeBuffer), 0, Random.Range(minZBound + edgeBuffer, maxZBound - edgeBuffer));
            Instantiate(cratePrefab, randomPos, transform.rotation);
        }
    }
}
