using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : MonoBehaviour
{
    //public GameObject projectilePrefab; //
   // public Transform launchPoint; //

   // public float shootTime;     // cooldown between projectiles    //
   // public float shootCounter;  // cooldown timer                  //

    Rigidbody2D playerRb;


    InputAction moveAction;
    InputAction jumpAction;
    //InputAction throwAction; //

    Vector2 moveInput;

    public float KBForce;       //knockback force
    public float KBCounter;     // räknar hur länge knockback är kvar på effekten
    public float KBTotalTime;   // hur länge knockback effekten vara kvar all tillsammans

    public bool KnockFromRight;


    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    

    //[SerializeField] Vector2 throwForce;  //


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");    
       //throwAction = InputSystem.actions.FindAction("Throw");                   //
       // shootCounter = shootTime; // starts countdown when you start the game    //

    }


    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPerformedThisFrame())
        {
            playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

      //  if (throwAction.WasPerformedThisFrame())                //
        //    {
       //     playerRb.AddForce(transform.up * throwForce);       //
     //   }
        

    }

   

    void FixedUpdate()
    {


        playerRb.linearVelocityX = moveInput.x * moveSpeed;



        // playerRb.linearVelocityX = moveInput.x * moveSpeed;



        
    }
}
