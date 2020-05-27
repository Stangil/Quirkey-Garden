using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    private void Start()
    {
        SetLaneSpawner();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }


    private void Update()
    {
        if (IsAttacherInLane())
        {
            Debug.Log("Attack");
            //TODO change animation state to attack
        }
        else
        {
            Debug.Log("Sit and Wait");
            //TODO change animation state to  Idle
        }
    }

    private bool IsAttacherInLane()
    {
       if(myLaneSpawner.transform.childCount <= 0)
        {
            return false; 
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}

