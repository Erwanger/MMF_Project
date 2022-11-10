using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu_UI_Controller : MonoBehaviour
{
    [SerializeField] GameObject emailInput_GO;
    [SerializeField] GameObject passwordInput_GO;
    [SerializeField] GameObject messageText_GO;
    [SerializeField] GameObject panelLogin_GO;
    [SerializeField] GameObject panelMenu_GO;


    [HideInInspector]
    public TMP_InputField emailInput;
    [HideInInspector]
    public TMP_InputField passwordInput;
    [HideInInspector]
    public TextMeshProUGUI messageText;

    public PlayfabManager playfabManager;

    bool loggedIn = false;

    private void Start()
    {
        emailInput = emailInput_GO.GetComponent<TMP_InputField>();
        passwordInput = passwordInput_GO.GetComponent<TMP_InputField>();
        messageText = messageText_GO.GetComponent<TextMeshProUGUI>();
        panelMenu_GO.SetActive(loggedIn);
        panelLogin_GO.SetActive(!loggedIn);
    }

    public void LoggedIn()
    {
        loggedIn = true;
        panelMenu_GO.SetActive(loggedIn);
        panelLogin_GO.SetActive(!loggedIn);
    }

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
