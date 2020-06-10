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
    public void LoadYouLose()
    {
        Debug.Log("Game over");
        SceneManager.LoadScene("LoseScreen");
    }
}
