using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSceneController : MonoBehaviour
{
    [Header("Racers")]
    public List<GameObject> racers = new List<GameObject>();
    public static List<Transform> racerTransforms = new List<Transform>();

    [Header("UI")]
    public Canvas canvas;
    public Button startButton;

    private int numRacers;
    private int racersFinished;

    void Start()
    {
        racersFinished = 0;
        foreach (GameObject racer in racers)
        {
            racerTransforms.Add(racer.transform);
        }
    }

    void Update()
    {
        if (racersFinished >= numRacers)
        {
            StopRace();
        }
    }

    void RandomiseRacers()
    {
        List<GameObject> temp = new List<GameObject>(racers);
        numRacers = Random.Range(6, racers.Count + 1);
        racerTransforms.Clear();
        for (int j = 0; j < numRacers; j++)
        {
            int index = Random.Range(0, temp.Count);
            racerTransforms.Add(temp[index].transform);
            temp.RemoveAt(index);
        }
    }

    public void StartRace()
    {
        RandomiseRacers();
        racersFinished = 0;
        startButton.gameObject.SetActive(false);
        foreach (Transform racer in racerTransforms)
        {
            racer.gameObject.GetComponent<Racer>().StartRace();
        }
    }

    private void StopRace()
    {
        startButton.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Racer>())
        {
            other.gameObject.GetComponent<Racer>().Stop();
            racersFinished++;
        }
    }
}
