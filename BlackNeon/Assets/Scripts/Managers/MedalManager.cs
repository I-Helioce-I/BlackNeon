using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalManager : MonoBehaviour
{
    [SerializeField]
    float[] timesPerMedals;

    [SerializeField]
    bool copper, silver, gold, platin;

    void CheckMedals(float timeDone)
    {
        if(timeDone == 0)
        {
            return;
        }

        foreach (float times in timesPerMedals)
        {

        }

    }
}
