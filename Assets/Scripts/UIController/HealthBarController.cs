using System;
using UnityEngine;
using UnityEngine.UI;
using World.Actors;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    
    [SerializeField]
    private LivingCharacter livingCharacter;

    public LivingCharacter LivingCharacter => livingCharacter;
    
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    private void Start()
    {
        SetMaxHealth(LivingCharacter.maximumHealth);
    }

    private void Update()
    {
        SetHealth(LivingCharacter.currentHealth);
    }
}
