using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] float delayBeforeSceneLoad = 3.0f;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreenAfterDelay());
        }
        else
        {
            //LoadNextScene();
        }
    }

    IEnumerator LoadStartScreenAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad);
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }
    public void LoadYouLose()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
