using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D enemyRb;

    

    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance;

    [SerializeField] Transform groundCheckPosition;
    [SerializeField] Transform lookPosition;

    [SerializeField] bool isGrounded;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(lookPosition. position, Vector2.down, checkDistance, groundLayer);
        RaycastHit2D groundHit = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, checkDistance, groundLayer);

        if(hit.collider == null && isGrounded)
        { 
             //flippa enemyn

           transform.rotation *= Quaternion.Euler(0f, 180f, 0f);


        }

        if(groundHit.collider != null )
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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




}