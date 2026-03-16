using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Enemy : MonoBehaviour
{

    Rigidbody2D enemyRb;

 

    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance;

    DD_PlayerScript playerScript;

    [SerializeField] Transform lookPosition;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        playerScript = FindAnyObjectByType<DD_PlayerScript>();
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(lookPosition. position, Vector2.down, checkDistance, groundLayer);
      

        if(hit.collider == null )
        { 
             //flippa enemyn

           transform.rotation *= Quaternion.Euler(0f, 180f, 0f);


        }

        
    }



    private void FixedUpdate() 
    {
        MoveEnemy();
        

    }


    void MoveEnemy()
    {
        enemyRb.linearVelocityX = transform.right.x * moveSpeed;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          playerScript.KnockBackCounter = playerScript.KnockBackTotalTime;
          if (collision.transform.position.x <= transform.position.x)
          {
              playerScript.KnockFromRight = true;
          }
          if (collision.transform.position.x > transform.position.x)
          {
                playerScript.KnockFromRight = false;
          }
        }
        enemyRb.linearVelocityY = 0;
        
    }



}