using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBase : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Debug.Log("Base collision");
        FindObjectOfType<BaseHealth>().DamageHealth(10);
    }
}
