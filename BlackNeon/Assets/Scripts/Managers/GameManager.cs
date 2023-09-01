using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [Header("Level Infos")]
    [SerializeField] string levelName;
    [SerializeField] Timer timer = null;
    [SerializeField] UIManager uiManager;

    //// The static instance that holds the reference to the Singleton object

    // Public property to access the Singleton instance
    public static GameManager Instance
    {
        get
        {
            // Check if the instance is null and find it in the scene if needed
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                // If it's still null, create a new GameObject and add the Singleton script to it
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    _instance = singletonObject.AddComponent<GameManager>();
                }

                //// Make sure the Singleton object persists through scene changes
                //DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }


    private void Start()
    {
        timer = GetComponent<Timer>();
        Time.timeScale = 0;
        PlayFabManager.Instance.GetLeaderboard("Level_" + levelName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !timer.IsStarted())
        {
            UIManager.Instance.HideStartPanel();
            Time.timeScale = 1;
            timer.SetStart();
        }
    }

    public UIManager GetCurrentUIManager()
    {
        return uiManager;
    }

    public void OnDeath()
    {
        SceneManager.LoadScene("Level_" + levelName);
    }

    public void OnFinishLane()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowEndPanel();
        
        PlayFabManager.Instance.SendLeaderboard("Level_" + levelName, timer.GetCurrentScore());
    }

}
