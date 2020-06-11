using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefab;
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        System.Random random = new System.Random();
        int index = random.Next(attackerPrefab.Length);
        Spawn(index);
    }

    private void Spawn(int index)
    {
        Attacker newAttacker = Instantiate(attackerPrefab[index], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
