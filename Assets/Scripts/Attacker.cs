using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range (0f,5f)]
    float currentSpeed = 0.0f;
    [SerializeField] int health = 200;
  
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
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
        Debug.Log("I'm Hit!");
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
