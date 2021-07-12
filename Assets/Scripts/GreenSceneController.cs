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
        numRacers = racers.Count;
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

    public void StartRace()
    {
        racersFinished = 0;
        startButton.gameObject.SetActive(false);
        foreach (GameObject racer in racers)
        {
            racer.GetComponent<Racer>().StartRace();
        }
    }

    private void StopRace()
    {
        racersFinished = 0;
        startButton.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Racer>())
        {
            if (other.gameObject.GetComponent<Racer>().IsFinished()) {
                racersFinished++;
                Debug.Log(other.gameObject.name + " has finished, total: " + racersFinished.ToString());
            }
        }
    }
}
