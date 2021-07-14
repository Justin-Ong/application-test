using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Input")]
    public KeyCode menuKey;
    public KeyCode reloadKey;

    [Header("Scene Management")]
    public Canvas loadingScreen;
    public float minLoadTime = 1f;

    public static PlayerController instance;

    private string currSceneName;
    private Slider loadingBar;

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
        loadingScreen.gameObject.SetActive(false);
        loadingBar = loadingScreen.transform.Find("LoadingBar").GetComponent<Slider>();
        currSceneName = SceneManager.GetActiveScene().name;
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

    public void ChangeScene(string newScene)
    {
        loadingScreen.gameObject.SetActive(true);
        currSceneName = newScene;
        DOTween.Clear(true); // Stop tweens before changing scenes to prevent errors
        StartCoroutine(LoadScene(newScene));
    }

    private IEnumerator LoadScene(string newScene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene);

        float startTime = Time.time;
        while (!asyncLoad.isDone)
        {
            loadingBar.value = asyncLoad.progress;

            yield return null;
        }
        float endTime = Time.time;
        System.GC.Collect();
        yield return new WaitForSeconds(minLoadTime - (endTime - startTime));
        loadingScreen.gameObject.SetActive(false);
    }
}
