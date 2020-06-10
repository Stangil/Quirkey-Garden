using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    Text healthText;
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
            health -= damage;
            UpdateDisplay();
        if(health <=0)
        {
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}
