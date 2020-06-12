using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBase : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<BaseHealth>().DamageHealth(10);
    }
}
