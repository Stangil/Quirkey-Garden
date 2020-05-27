using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1.0f;
    [SerializeField] float spin = 100.0f;
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime,Space.World);
        transform.Rotate(Vector3.forward, spin * Time.deltaTime);
    }
}
