
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
   
    Rigidbody2D playerRb;


    InputAction moveAction;
    InputAction jumpAction;
    InputAction throwAction; 

    Vector2 moveInput;

    public bool isFacingRight;

    [SerializeField] List<Transform> bulletShootpoints;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    

    [SerializeField] GameObject dagger;

    AudioManager audioManager;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");    
       throwAction = InputSystem.actions.FindAction("Attack");
        audioManager = FindAnyObjectByType<AudioManager>();
        isFacingRight = true;

    }


    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPerformedThisFrame())
        {
            playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

      //   if (throwAction.WasPerformedThisFrame())                
      //   {
            
      //      Instantiate(dagger, bulletShootpoints[0].position, Quaternion.identity);

        //    Debug.Log("THROW");                 
      //   }

        if (isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

    }

    void ReadPlayerInputs()
    {

        moveInput = moveAction.ReadValue<Vector2>();

       

        if (moveInput.x > 0)
        {
            isFacingRight = true;
        }
        else if (moveInput.x < 0)
        {
            isFacingRight = false;
        }

    }

    void FixedUpdate()
    {
        ReadPlayerInputs();

        playerRb.linearVelocityX = moveInput.x * moveSpeed;



        // playerRb.linearVelocityX = moveInput.x * moveSpeed;



        
    }


    public void PlayFootStep()
    {
        FindAnyObjectByType<AudioManager>().playsound(0);

    }

   

    //private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        playerHealth--;
    //       lifeTExt.text = playerHealth.ToString();
    //      Debug.Log("playerHealth:" + playerHealth);
    //      if (playerHealth <= 0)
    //      {
    //           Destroy(gameObject);
    //         Debug.Log("Game Over!");
    //     }
    //  }
    //}
}
