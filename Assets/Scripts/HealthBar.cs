using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private HealthController healthController;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        healthController.OnHealthChange += OnHealthChange;
        slider.maxValue = healthController.MaxHealth;
        slider.value = healthController.Health;
    }

    void OnHealthChange(int health) {   
        slider.value = health;
    }

    private void OnDestroy() {
        healthController.OnHealthChange -= OnHealthChange;    
    }

}
