
using UnityEngine;
using UnityEngine.Rendering;


public class Enemy : MonoBehaviour //, IDamageable
{

    Health healthSystem;
    Rigidbody2D enemyRb;

    public float KBF;
    public float KBC;
    public float KBTT;

    public bool KFR;

    public int enemyLife;
    public int maxEnemyLife;

    //[SerializeField] private float maxHealth = 3f;  //health

    private float currentHealth; // health


    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDistance;

    DD_PlayerScript playerScript;

    [SerializeField] Transform lookPosition;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        playerScript = FindAnyObjectByType<DD_PlayerScript>();

       // currentHealth = maxHealth; // health

        enemyRb = GetComponent<Rigidbody2D>();
        enemyLife = maxEnemyLife;
        healthSystem = FindAnyObjectByType<Health>();
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(lookPosition.position, Vector2.down, checkDistance, groundLayer);


        if(hit.collider == null )
        { 
             //flippa enemyn

           transform.rotation *= Quaternion.Euler(0f, 180f, 0f);


        }

        
    }



    private void FixedUpdate() 
    {
        MoveEnemy();
        EnemyKnockBack();

    }


    void MoveEnemy()
    {
        enemyRb.linearVelocityX = transform.right.x * moveSpeed;
    }

    void EnemyKnockBack()
    {
        if (KBC <= 0)
        {
            enemyRb.linearVelocity = new Vector2(enemyRb.linearVelocity.x * moveSpeed, enemyRb.linearVelocity.y);
        }
        else
        {
            if (KFR == true)
            {
                enemyRb.linearVelocity = new Vector2(KBF, KBF);
            }
            if (KFR == false)
            {
                enemyRb.linearVelocity = new Vector2(-KBF, KBF);
            }

            KBC -= Time.fixedDeltaTime;
        }

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
        enemyRb.AddForce(Vector2.up * KBF, ForceMode2D.Impulse);

        if (collision.gameObject.CompareTag("Player"))
        {
            healthSystem.TakeDamage(1);
        }

    }




}