using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        loseLabel.SetActive(false);
        winLabel.SetActive(false);
    }
    public void AttackerHasSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void LoseCondition()
    {
        StartCoroutine(HandleLoseCondition());
    }
    IEnumerator HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        StopSpawners();
        yield return new WaitForSeconds(waitToLoad);
    }
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
