using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;


public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public Menu_UI_Controller uiController;

    public void Register(string email, string password)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = password,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        uiController.DisplayMessage("Registered and logged in!");
        uiController.LoggedIn();
    }

    void OnError(PlayFabError error)
    {
        uiController.DisplayMessage("Error!");
        Debug.Log(error.GenerateErrorReport());
    }

    void OnLoginSuccess(LoginResult result)
    {
        uiController.DisplayMessage("Logged in!");
        uiController.LoggedIn();
    }

    public void Login(string email, string password)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = password
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void ResetPassword()
    {

    }
}
