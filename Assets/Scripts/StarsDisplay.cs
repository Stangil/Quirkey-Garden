using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
    public void AddStars(int starsToAdd)
    {
        stars += starsToAdd;
        UpdateDisplay();
    }
    public void SpendStars(int starsToSpend)
    {
        if (stars >= starsToSpend)
        {
            stars -= starsToSpend;
            UpdateDisplay();
        }
    }
    public int GetStarsTotal()
    {
        return stars;
    }
    public bool HaveEnoughStars(int amount)
    {
        if (amount <= stars)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}