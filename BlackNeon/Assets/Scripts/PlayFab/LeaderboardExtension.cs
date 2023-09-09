using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class LeaderboardExtension
{
	public static void DebugLeaderboard(this List<LeaderboardEntry> entryList)
	{
		StringBuilder stringBuilder = new StringBuilder();

		foreach (var item in entryList)
		{
			stringBuilder.AppendLine(item.ToString());
		}

		Debug.Log(stringBuilder.ToString());
	}
}
