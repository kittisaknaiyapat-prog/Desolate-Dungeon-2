using System;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public int currentHealth {get; private set; }
    public int maxHealth { get; private set; }
    public static Action<int> onPlayerTakeDamage;

    void Awake()
    {
     currentHealth = health;
        maxHealth = health; 
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        onPlayerTakeDamage?.Invoke(currentHealth);

        if (currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
