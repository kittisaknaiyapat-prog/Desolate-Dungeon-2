using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class New_ : MonoBehaviour
{
    // I am trying (=
    [Header("Components")]
    public Animator Anim;
    public Rigidbody2D rb2d;
    public PlayerInput playerInput;

    [Header("Movment")]
    public float speed;
    public Vector2 moveValue;
    public int facingdirection = 1;

    [Header("jump")]
    public float jumpPower;
    public float jumpCuthight = .5f;

    [Header("gravity")]
    public float normalGravity;
    public float dashGravity;
    public float fallingGravity;
    public float jumpingGravity;

    [Header("groundcheak")]
    public Transform groundcheak;
    public float groundcheakingradius;
    public LayerMask floor;
    private bool isgrounded;

    [Header("Dash(not workign)")]
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashingpower = 24f;
    [SerializeField] private float dashCooldown = 1f;


    //Failure

    //not working
    private void Start()
    {
        rb2d.gravityScale = normalGravity;
    }


    void FixedUpdate()
    {
        groundcheaking();
        variableGravity();
        haldelMovment();
    }
    void Update()
    {
        flip();
        HandelAnimation();
        if (isDashing)
        {
            return;
        }
    }

    void haldelMovment()
    {
        float targetspeed = moveValue.x * speed;
        rb2d.linearVelocity = new Vector2(targetspeed, rb2d.linearVelocity.y);
    }

    //joakim animation work (=
    void HandelAnimation()
    {
        Anim.SetBool("is_jumping", rb2d.linearVelocity.y > .1f);
        Anim.SetBool("is_grounded", isgrounded);

        Anim.SetFloat("Yvelocity", rb2d.linearVelocity.y);

        Anim.SetBool("is_idle", Mathf.Abs(moveValue.x) < .1f && isgrounded);
        Anim.SetBool("is_walking", Mathf.Abs(moveValue.x) > .1f && isgrounded);
    }
    //Work now 
    void variableGravity()
    {
        if (rb2d.linearVelocityY < -0.1f)
        {
            rb2d.gravityScale = fallingGravity;
        }
        else if (rb2d.linearVelocityY > 0.1f)
        {
            rb2d.gravityScale = jumpingGravity;
        }
        else
        {
            rb2d.gravityScale = normalGravity;
        }
    }
    void groundcheaking()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheak.position, groundcheakingradius, floor);
    }
    void flip()
    {
        if (moveValue.x > 0.01f)
        {
            facingdirection = 1;

        }
        else if (moveValue.x < -0.01f)
        {
            facingdirection = -1;
        }



        transform.localScale = new Vector3(facingdirection, 1, 1);

    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb2d.gravityScale = dashGravity;
        rb2d.linearVelocity = new Vector2(transform.localScale.x * dashingpower, 0f);
        yield return new WaitForSeconds(dashTime);
      // was code here but it didn't work so move alonge
        rb2d.gravityScale = normalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void OnMove(InputValue value)
    {

        moveValue = value.Get<Vector2>();


    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isgrounded)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, jumpPower);
        }
        else
        {

            if (rb2d.linearVelocityY > 0)
            {
                rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, rb2d.linearVelocityY * jumpCuthight);
            }

        }


    }

    // all this code is being made 2026-05-21 form 18:56 to 2026-05-22 01:24. so if i am tired during the presentation please be nice




}

