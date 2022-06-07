using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;

    private void Awake() 
    {
        TryGetComponent(out healthBar);    
    }

    public void UpdateHealthBar(float newValue)
    {
        healthBar.value = newValue;
    }

    public void StartHealthBar(float newMaxValue)
    {
        healthBar.maxValue = newMaxValue;
        healthBar.value = newMaxValue;
    }
}
