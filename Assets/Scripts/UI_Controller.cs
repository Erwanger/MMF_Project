using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    void OpenActionPanel(bool isLgAction)
    {

    }

    public void OnLgActionButton_Clicked()
    {
        OpenActionPanel(true);
    }

    public void OnShrtActionButton_Clicked()
    {
        OpenActionPanel(false);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnQuitButton_Clicked()
    {
        Application.Quit();
    }

}
