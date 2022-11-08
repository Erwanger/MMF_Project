using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu_UI_Controller : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI messageText;

    public PlayfabManager playfabManager;


    public void OnClick_Login()
    {
        playfabManager.Login(emailInput.text, passwordInput.text);
    }

    public void OnClick_Register()
    {
        playfabManager.Register(emailInput.text, passwordInput.text);
    }

    public void DisplayMessage(string errorText)
    {
        messageText.text = errorText;
    }

    public void OnClick_ResetPassword()
    {
        playfabManager.ResetPassword();
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
