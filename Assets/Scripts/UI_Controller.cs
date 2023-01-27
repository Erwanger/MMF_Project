using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    void OpenActionPanel(bool isLgAction)
    {
        if(isLgAction)
        {
            //Faire dégats puis terminer tour
        }
        else
        {
            //Faire degats, griser Boutn Longue Action
        }
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
