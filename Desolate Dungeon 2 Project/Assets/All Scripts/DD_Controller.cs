using System.Collections;
using UnityEngine;

public class DD_Controller : MonoBehaviour
{
    Vector2 StartPosition;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private GameObject deathEffect;
    DD_PlayerScript playerScript;
    public int HealthPoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<DD_PlayerScript>();
        HealthPoints = 100;

    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.CompareTag("TestEnemy"))
        { 
          playerScript.TakingDmg();
          Die();

        }
   }

 

    private void DeathParticles()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

    }


    void Die()
    {
        StartCoroutine(Respawn(0.5f));
        DeathParticles();

    }

    IEnumerator Respawn(float duration)
    {
        rb.simulated = false;
        rb.linearVelocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = StartPosition;
        transform.localScale = new Vector3(1, 1, 1);
        rb.simulated = true;
    }


   
}
