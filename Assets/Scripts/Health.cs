using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 200;
    [Header("Effects")]
    [SerializeField] GameObject explosionParticles;
    [SerializeField] float durationOfExplosion = 1.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    internal void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void TriggerDeathVFX()
    {
        if (!explosionParticles)
        {
            return;
        }
        GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, durationOfExplosion);
    }
}
