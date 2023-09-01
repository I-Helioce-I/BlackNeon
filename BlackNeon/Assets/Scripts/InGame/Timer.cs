using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] bool start = false;
    [SerializeField] float currentTime;
    [SerializeField] bool countDown;

    [Header("Limit Settings")]
    [SerializeField] bool hasLimit;
    [SerializeField] float timerLimit;

    public bool IsStarted()
    {
        return start;
    }
    public void SetStart()
    {
        start = true;
        currentTime = 0;
    }

    private void Update()
    {
        if (start)
        {

            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

            if (hasLimit && ((countDown && currentTime <= timerLimit || (!countDown && currentTime >= timerLimit))))
            {
                currentTime = timerLimit;
                SetTimerText();
                // need to add stuff here like color && disable it
            }
        }
        SetTimerText();
    }

    void SetTimerText()
    {
        UIManager.Instance.UpdateTimerText(currentTime);
    }

    public int GetCurrentScore()
    {
        return (int)(currentTime * 1000000);
    }

}
