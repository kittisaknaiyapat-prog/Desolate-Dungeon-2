using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class DD_Controller : MonoBehaviour
{
    Vector2 StartPosition;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private GameObject deathEffect;
    DD_PlayerScript playerScript;
    public int HealthPoints;

    AudioController audioController;

    bool isDead = false;



    private void Start()    
    {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<DD_PlayerScript>();
        HealthPoints = 100;
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();

    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.CompareTag("TestEnemy"))
        {
          playerScript.TakingDmg();
            Die();

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerScript.TakingDmg();
            HealthPoints -= 10;
        }

        if (HealthPoints <= 0)
        {
            Die();

        }
    }

 

    private void DeathParticles()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);


    }


    


    void Die()
    {
        isDead = true;
        StartCoroutine(Respawn(0.5f));
        DeathParticles();
        audioController.PlaySFX(audioController.death);
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
        isDead = false;
        HealthPoints = 100;
    }


   
}
