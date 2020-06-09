﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            if(otherObject.name == "Gravestone")
            {
                GetComponent<Animator>().SetTrigger("Jumping");
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
           
        }
    }
}
