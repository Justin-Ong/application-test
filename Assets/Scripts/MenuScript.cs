using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    AsyncOperation load;

    public void RedSceneSelected()
    {
        PlayerController.instance.ChangeScene("RedScene");
        DisplayLoadingScreen(load);
    }

    public void BlueSceneSelected()
    {
        PlayerController.instance.ChangeScene("BlueScene");
        DisplayLoadingScreen(load);
    }

    public void GreenSceneSelected()
    {
        PlayerController.instance.ChangeScene("GreenScene");
        DisplayLoadingScreen(load);
    }

    void DisplayLoadingScreen(AsyncOperation loadingScene)
    {
        Debug.Log("Loading");
    }
}
