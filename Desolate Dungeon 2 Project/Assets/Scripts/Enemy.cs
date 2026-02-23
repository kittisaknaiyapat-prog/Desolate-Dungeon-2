using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D enemyRb;


    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance;

    [SerializeField] Transform lookPosition;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(lookPosition. position, Vector2.down, checkDistance, groundLayer);

        if(hit.collider == null)
        {
            // flippa enemyn

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




}