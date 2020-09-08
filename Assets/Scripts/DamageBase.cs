using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBase : MonoBehaviour
{
    float damage = 1;
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        
        FindObjectOfType<BaseHealth>().DamageHealth(damage);
        Destroy(otherCollider.gameObject);
    }
}
