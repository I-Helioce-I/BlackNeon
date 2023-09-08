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

    [SerializeField]
    Transform levelSpawnTransform;

    private void Start()
    {

    }

    public void OnCLickPlay()
    {
        SetUpLevels();
    }

    void SetUpLevels()
    {
        foreach (Object level in scenes)
        {
            GameObject levelButton = Instantiate(buttonPrefab, levelSpawnTransform);
            LevelButton levelButtonScript = levelButton.GetComponent<LevelButton>();

            levelButtonScript.SetUpName(level.name);
        }
    }

    //

    public void QuitApplication()
    {
        Application.Quit();
    }
}
