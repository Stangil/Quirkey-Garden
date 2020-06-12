﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    [Range (0f,5f)]
    float currentSpeed = 0.0f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerHasSpawned();
    }
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();//.AttackerKilled();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }
    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
   
}
