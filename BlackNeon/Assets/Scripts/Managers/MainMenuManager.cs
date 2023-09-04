using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    Object[] scenes;

    [SerializeField]
    GameObject buttonPrefab;

    private void Start()
    {
        SetUpLevels();
    }

    void SetUpLevels()
    {
        foreach (Object level in scenes)
        {
            GameObject levelButton = Instantiate(buttonPrefab);
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
