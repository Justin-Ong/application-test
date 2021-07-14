using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public KeyCode menuKey;
    public KeyCode reloadKey;

    public static PlayerController instance;

    private string currSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(currSceneName);
    }

    void Update()
    {
        if (Input.GetKeyUp(menuKey) && currSceneName != "MenuScene") {
            ChangeScene("MenuScene");
        }
        else if (Input.GetKeyUp(reloadKey)) {
            ChangeScene(currSceneName);
        }
    }

    public AsyncOperation ChangeScene(string newScene)
    {
        currSceneName = newScene;
        DOTween.Clear(true); // Stop tweens before changing scenes to prevent errors
        return (SceneManager.LoadSceneAsync(newScene));
    }
}
