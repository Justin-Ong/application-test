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
    private Transform mainCamera;
    private float initialCameraDistance;
    private List<GameObject> racers;
    private Dictionary<GameObject, Transform> nameTags = new Dictionary<GameObject, Transform>();

    private void Start()
    {
        startButton = gameObject.transform.GetChild(0).gameObject;
        mainCamera = Camera.main.transform;
        initialCameraDistance = mainCamera.position.y;
    }

    private void LateUpdate()
    {
        foreach (GameObject name in nameTags.Keys)
        {
            name.transform.position = nameTags[name].transform.position + Vector3.forward + Vector3.up;
            name.GetComponent<TextMeshPro>().fontSize = nameFontSize * (mainCamera.position.y / initialCameraDistance);
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
            TextMeshPro newTextMesh = newName.AddComponent<TextMeshPro>();
            newTextMesh.text = racer.name;
            newTextMesh.fontSize = nameFontSize;
            newTextMesh.horizontalAlignment = HorizontalAlignmentOptions.Center;
            newTextMesh.verticalAlignment = VerticalAlignmentOptions.Middle;
            newTextMesh.material = textMaterial;
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
