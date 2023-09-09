using System;

public class LeaderboardEntry : IComparable
{
	public string username;
	public int statValue;
	public string PlayFabId;

	public LeaderboardEntry(string username, int statValue, string PlayFabId)
	{
		this.username = username;
		this.statValue = statValue;
		this.PlayFabId = PlayFabId;
	}
	 
	public int CompareTo(object obj)
	{
		return statValue - ((LeaderboardEntry)obj).statValue;
	}

	public override string ToString()
	{
		// string interpolation
		return $"{username} : {statValue}";
	}
}
