using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    DD_Controller controllerScript;
    public int health;
    public int maxHealth = 10;
    public Slider slider;
    


    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        controllerScript = GetComponent<DD_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void Reset()
    {
       health = maxHealth;
         slider.value = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;

        if (health <= 0)
        {
            Reset();
        }

    }



}
