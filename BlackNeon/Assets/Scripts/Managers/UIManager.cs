using PlayFab.ProfilesModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIManager : MonoBehaviour
{
    // The static instance that holds the reference to the Singleton object
    private static UIManager _instance;

    [Header("Text"), SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI chargeText;
    [SerializeField]
    public GameObject chargeShortcutPanel;

    [Header("Charges")]
    public Button add;
    public Button substract;
    public Button multiply;
    public Button divide;

    [Header("StartPanel")]
    [SerializeField]GameObject startPanel;
    [Header("EndPanel")]
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI endPanelTimer;



    [Header("Leaderboard")]
    [SerializeField]
    GameObject rowPrefab;

    [SerializeField]
    public Transform rowsParent;

    public Slider slider;


    // Public property to access the Singleton instance
    public static UIManager Instance
    {
        get
        {
            // Check if the instance is null and find it in the scene if needed
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();

                // If it's still null, create a new GameObject and add the Singleton script to it
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(UIManager).Name);
                    _instance = singletonObject.AddComponent<UIManager>();
                }

                //// Make sure the Singleton object persists through scene changes
                //DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }


    public void UpdateTimerText(float actualTimer)
    {
        timerText.text = actualTimer.ToString("0.000000");
    }

    public void UpdateChargeText(int chargeToUpdate)
    {
        chargeText.text = chargeToUpdate.ToString();
    }

    public void DisplayChargeShortcut(bool isActive)
    {
        chargeShortcutPanel.SetActive(isActive);
    }

    public void HideStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
        endPanelTimer.text = timerText.text;
    }

    public void SetLeaderBoard(string position, string username, string statValue)
    {
        GameObject newGo = Instantiate(rowPrefab, rowsParent);
        RowManager newGORowManager = newGo.GetComponent<RowManager>();
        newGORowManager.SetRow(position, username, statValue);
    }

    public void UpdateSlider(float value)
    {
        slider.value = value;
    }

    //public void UdateCharges(ActionController aC)
    //{
    //    if(aC.)
    //}

    //public void UpdateCharge(PlayerController pc)
    //{
    //    if (pc.add)
    //    {
    //        add.interactable = true;
    //    }

    //    if (pc.substract)
    //    {
    //        substract.interactable = true;
    //    }
    //    if (pc.multiply)
    //    {
    //        multiply.interactable = true;
    //    }
    //    if (pc.divide)
    //    {
    //        divide.interactable = true;
    //    }
    //}
}
