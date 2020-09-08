using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    float health = 5f;
    Text healthText;
    bool dead = false;
    void Start()
    {
        health -= PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
   
    public void DamageHealth(float damage)
    {
        if (dead) { return; }
            health -= damage;
            UpdateDisplay();
        if(health <=0)
        {
            health = 0;
            UpdateDisplay();
            dead = true;
            FindObjectOfType<LevelController>().LoseCondition();
        }
    }
}
