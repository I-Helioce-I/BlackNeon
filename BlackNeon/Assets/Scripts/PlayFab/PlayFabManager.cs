using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager Instance;

    [SerializeField]
    string playFabID;

    [SerializeField]
    public string displayName;

    PlayerProfileModel playerProfile;

    [SerializeField]
    float previousScore;

    private void Start()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this.gameObject);

        previousScore = 0;
    }

    public void SetPlayFabIDName(string playfabID)
    {
        playFabID = playfabID;

        GetPlayerProfile(playfabID);
    }

    public void SendLeaderboard(string levelName, int score)
    {

        //if (previousScore <= score || previo)
        //{
        //    return;
        //}

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = levelName,
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);

    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Success leaderboard send to " + result.Request);
    }

    public void GetLeaderboard(string levelName)
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = levelName,

        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);

    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in UIManager.Instance.rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            if(item.PlayFabId == playFabID)
            {
                previousScore = item.StatValue;
            }

            float timeBeforeConvertion = item.StatValue;
            float timeAferConvertion = timeBeforeConvertion / 1000000;
            UIManager.Instance.SetLeaderBoard((item.Position +1).ToString(), item.DisplayName, timeAferConvertion.ToString());
            
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error);
    }

    void GetPlayerProfile(string playFabId)
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            }
        },
        result => playerProfile = result.PlayerProfile,
        error => Debug.LogError(error.GenerateErrorReport()));

    }

}
