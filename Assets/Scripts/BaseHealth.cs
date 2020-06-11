using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    Text healthText;
    bool dead = false;
    void Start()
    {
      
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
   
    public void DamageHealth(int damage)
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
