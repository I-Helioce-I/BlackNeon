using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
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
		foreach (Transform item in UIManager.Instance.rowsParent)
		{
			Destroy(item.gameObject);
		}

		List<LeaderboardEntry> leaderboardEntry = new List<LeaderboardEntry>();

		foreach (var item in result.Leaderboard)
		{
			leaderboardEntry.Add(new LeaderboardEntry(item.DisplayName, item.StatValue, item.PlayFabId));
		}

		leaderboardEntry.Sort();

		leaderboardEntry.DebugLeaderboard();

		for (int i = 0; i < leaderboardEntry.Count; i++)
		{
			LeaderboardEntry entry = leaderboardEntry[i];
			if (entry.PlayFabId == playFabID)
			{
				previousScore = entry.statValue;
			}

			float timeBeforeConvertion = entry.statValue;
			float timeAferConvertion = timeBeforeConvertion / 1000000;
			UIManager.Instance.SetLeaderBoard((i + 1).ToString(), entry.username, timeAferConvertion.ToString());

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
