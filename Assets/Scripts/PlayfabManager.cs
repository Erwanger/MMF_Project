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
    }

    void OnError(PlayFabError error)
    {
        uiController.DisplayMessage("Error!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void Login(string email, string password)
    {

    }

    public void ResetPassword()
    {

    }
}
