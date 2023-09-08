using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI levelName;

    

    public void SetUpName(string nameIn)
    {
        levelName.text = nameIn;

    }

    public void OnCLickOnLevel()
    {
        SceneManager.LoadScene(levelName.text);
    }
}
