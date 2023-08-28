using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoLogoHelioce;
    [SerializeField]
    VideoPlayer videoAllLogo;

    private void Start()
    {
        StartCoroutine(SplashScreenCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(SplashScreenCoroutine());
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator SplashScreenCoroutine()
    {
        videoLogoHelioce.gameObject.SetActive(true);
        videoLogoHelioce.Play();
        
        yield return new WaitForSeconds(4f);

        videoLogoHelioce.gameObject.SetActive(false);
        videoAllLogo.gameObject.SetActive(true);
        videoAllLogo.Play();

        yield return new WaitForSeconds(8f);

        videoAllLogo.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    } 
}
