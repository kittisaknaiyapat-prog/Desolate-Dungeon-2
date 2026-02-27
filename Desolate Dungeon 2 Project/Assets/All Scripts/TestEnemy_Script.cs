using UnityEngine;

public class TestEnemy_Script : MonoBehaviour
{
    public int health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once pper frame
    void Update()
    {

    }



    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death() 
    {
        Destroy(gameObject);
    }
}
