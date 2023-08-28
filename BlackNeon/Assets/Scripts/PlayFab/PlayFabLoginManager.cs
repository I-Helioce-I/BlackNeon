using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabLoginManager : MonoBehaviour
{
    [SerializeField]
    PlayFabManager playFabManager;

    [Header("Register")]
    [SerializeField]
    TMP_InputField emailIFRegitser, passwordlIFRegister, usernameIFRegister;

    [Header("Login")]
    [SerializeField]
    TMP_InputField emailIFLogin, passwordlIFLogin;

    [SerializeField]
    TextMeshProUGUI messageBox;

    [SerializeField]
    GameObject[] panels;

    private void Start()
    {
        playFabManager = PlayFabManager.Instance;
        ChangePannel(panels[1]);
    }

    public void OnClickGoToRegister()
    {
        ChangePannel(panels[0]);
    }

    public void OnClickGoToLogin()
    {
        ChangePannel(panels[1]);
    }

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailIFRegitser.text,
            Password = passwordlIFRegister.text,
            Username = usernameIFRegister.text,
            DisplayName = usernameIFRegister.text,
            RequireBothUsernameAndEmail = true
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucess, OnError);
    }

    void OnRegisterSucess(RegisterPlayFabUserResult result)
    {
        messageBox.text = "Register";
        ChangePannel(panels[1]);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailIFLogin.text,
            Password = passwordlIFLogin.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };


        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucess, OnError);
    }

    void OnLoginSucess(LoginResult result)
    {
        if(result.InfoResultPayload.PlayerProfile != null)
        {
            playFabManager.displayName = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        playFabManager.SetPlayFabIDName(result.PlayFabId);
         
        int loadScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(loadScene);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error);
    }

    void ChangePannel(GameObject panelToActivate)
    {
        foreach (GameObject panel in panels)
        {
            if (panel == panelToActivate)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }

        }
    }


}
