using UnityEngine;
using Facebook.Unity;
using System.Collections;
using System;
using UnityEngine.UI;

public class FacebookHolderScript : MonoBehaviour {

    public Button authButton;

	void Awake()
    {
        FB.Init(SetInit, OnHideUnity);
        authButton = GameObject.Find("FBAuthButton").GetComponent<Button>();
    }

    void Start()
    {
        if (FB.IsLoggedIn)
            authButton.GetComponent<Text>().text = "Logout";
    }

    private void SetInit()
    {
        Debug.Log("FB Init done");

        if (FB.IsLoggedIn)
            Debug.Log("FB Logged in");
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void LoginUser()
    {
        if (!FB.IsLoggedIn)
        {
            FB.LogInWithPublishPermissions();
            authButton.GetComponent<Text>().text = "Logout";
        } else
        {
            FB.LogOut();
            authButton.GetComponent<Text>().text = "Login";
        }
    }

    public void InviteFriends()
    {
        FB.AppRequest(
            message: "Check out Slamster",
            title: "Invite your friends to play"
            );
    }
}
