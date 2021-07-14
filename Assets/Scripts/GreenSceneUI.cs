using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreenSceneUI : MonoBehaviour
{
    public float nameFontSize = 8f;
    public Material textMaterial;

    private GameObject startButton;
    private List<GameObject> racers;
    private Dictionary<GameObject, Transform> nameTags = new Dictionary<GameObject, Transform>();

    private void Start()
    {
        startButton = gameObject.transform.GetChild(0).gameObject;
    }

    private void LateUpdate()
    {
        foreach (GameObject name in nameTags.Keys)
        {
            name.transform.position = nameTags[name].transform.position + Vector3.forward + Vector3.up;
        }
    }

    public void Setup(List<GameObject> input)
    {
        racers = input;
        AssignRacerNames();
    }

    private void AssignRacerNames()
    {
        foreach (GameObject racer in racers)
        {
            GameObject newName = new GameObject(racer.name + " nametag");
            newName.transform.position = racer.transform.position + Vector3.forward + Vector3.up;
            newName.AddComponent<TextMeshPro>();
            newName.GetComponent<TextMeshPro>().text = racer.name;
            newName.GetComponent<TextMeshPro>().fontSize = nameFontSize;
            newName.GetComponent<TextMeshPro>().horizontalAlignment = HorizontalAlignmentOptions.Center;
            newName.GetComponent<TextMeshPro>().verticalAlignment = VerticalAlignmentOptions.Middle;
            newName.GetComponent<TextMeshPro>().material = textMaterial;
            newName.transform.Rotate(new Vector3(90, 0, 0));    // Make nametag face up perpendicular to the ground
            nameTags.Add(newName, racer.transform);
        }
    }

    public void ShowButton()
    {
        startButton.gameObject.SetActive(true);
    }

    public void HideButton()
    {
        startButton.gameObject.SetActive(false);
    }
}
