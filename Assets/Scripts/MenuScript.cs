using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void RedSceneSelected()
    {
        PlayerController.instance.ChangeScene("RedScene");
    }

    public void BlueSceneSelected()
    {
        PlayerController.instance.ChangeScene("BlueScene");
    }

    public void GreenSceneSelected()
    {
        PlayerController.instance.ChangeScene("GreenScene");
    }
}
