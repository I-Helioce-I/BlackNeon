using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RowManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI rank, username, time;

    public void SetRow(string rankToSet, string usernameToSet, string timeToSet)
    {
        rank.text = rankToSet;
        username.text = usernameToSet;
        time.text = timeToSet;
        
    }
}
