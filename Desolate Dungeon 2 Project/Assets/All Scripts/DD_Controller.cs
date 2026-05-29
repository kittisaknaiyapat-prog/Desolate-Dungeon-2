using System.Collections;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class DD_Controller : MonoBehaviour
{
    Vector2 StartPosition;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private GameObject deathEffect;
    DD_PlayerScript playerScript;
    public int HealthPoints;
    public int MaxHealthPoints;


    AudioController audioController;
    Health health;

    bool isDead;

    [SerializeField] Slider healthSlider;


    private void Start()    
    {
        StartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<DD_PlayerScript>();
        HealthPoints = 100;
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        health = FindAnyObjectByType <Health>();
        HealthPoints = MaxHealthPoints;
        healthSlider.maxValue = MaxHealthPoints;
        healthSlider.value = HealthPoints;

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
            healthSlider.value = HealthPoints;
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

    public void Reset()
    {
        HealthPoints = MaxHealthPoints;
        healthSlider.value = MaxHealthPoints;
        
    }



    void Die()
    {
        isDead = true;
        StartCoroutine(Respawn(0.5f));
        DeathParticles();
        //audioController.PlaySFX(audioController.death);
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
        MaxHealthPoints = 100;
        Reset();
    }


   
}
