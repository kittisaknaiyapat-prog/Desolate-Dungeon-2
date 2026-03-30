using UnityEngine;

public class Mimic : MonoBehaviour
{

    public Transform patrolPointA;
    public Transform patrolPointB;
    private SpriteRenderer spriteRenderer;
    public float waitTime = 1.5f;

    private Vector2 movement;
    private Vector3 currentTarget;
    private bool playerDetected = false;
    private float waitCounter = 0f;
    private bool isWaiting = false;
    

    Rigidbody2D enemyRb;


    
   [SerializeField] Transform playerRb;
   [SerializeField] float moveSpeed;
   [SerializeField] float distance;
   [SerializeField] float attackRange = 5f;
   [SerializeField] LayerMask groundLayer;
   [SerializeField] float checkDistance;


    [SerializeField] Transform lookPosition;
    

    void Start()
    {
     enemyRb = GetComponent<Rigidbody2D>();
     playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

     spriteRenderer = GetComponent<SpriteRenderer>();
     currentTarget = patrolPointB.position;

        

    }




    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, playerRb.position);
        if (distance < attackRange) 
        {

            playerDetected = true;

             //attack();

        }
        else if (distance > attackRange + 1f) 
        {
            playerDetected = false;
        }

        if (playerDetected)
        {
            MoveTowards(currentTarget);
        }
        else
        {
            Patrol();
        }
            
  
    
      
       
        if (distanceToPlayer <= attackRange)
        {
            attack();
            
        }

       

        // if (direction == 1) //
        // {
        // eller transform.localScale = Vector3.one * moveSpeed;
        // transform.localScale = new Vector3(-1, 1, 1);
        //}else if (direction == -1) 
        //  {
        // transform.localScale = new Vector3(1, 1, 1);
        //  }

       // enemyRb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime, enemyRb.linearVelocity.y);

        RaycastHit2D hit = Physics2D.Raycast(lookPosition.position, Vector2.down, checkDistance, groundLayer);

       

    }


    void Patrol()
    {

       

        if (isWaiting)
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0f)
            {
                isWaiting = false;
                currentTarget = currentTarget == patrolPointA.position ? patrolPointB.position: patrolPointA.position;

            }
            return;
        }
        // behöver inte: Vector2.direction = (currentTarget - transform.position.x).normalized;

        MoveTowards(currentTarget);

        if (Vector2.Distance(transform.position, currentTarget) < 0.1f)
        {

            isWaiting = true;
            waitCounter = waitTime;

        }

        
    }



    void MoveTowards(Vector3 target)
    {

         Vector2 direction = (target - transform.position).normalized;
        transform.position += moveSpeed * Time.deltaTime * (Vector3)direction; 

        if(direction.x <0) spriteRenderer.flipX = true;
        else if (direction.x > 0) spriteRenderer.flipX = false;

       

    }


    void attack()
    {
        if(playerRb.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }


            transform.position = Vector2.MoveTowards(transform.position, playerRb.position, moveSpeed * Time.deltaTime);


    }

    private void OnCollisionEnter2D (Collision2D other)
    {
       // direction *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //direction *= -1;
    }

}
