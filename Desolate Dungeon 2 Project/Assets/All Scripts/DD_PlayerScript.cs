using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DD_PlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;
    public InputAction moveAction;
    public Vector2 moveInput;

    InputAction dashAction;
    InputAction jumpaction;
    private TrailRenderer trailRenderer;
    private bool dashInput;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    [Header("Ground check system")]
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    [Header("Player Status")]

    [SerializeField] int PlayerHealthPoints;
    private bool isInvincible;


    private SpriteRenderer Sprite;

    [Header("Dash Related")]
    [SerializeField] private float dashingVelocity;
    [SerializeField] private float dashingTime;
    private Vector2 dashDirection;
    private bool isDashing;
    private bool canDash = true;
    private bool isFacingRight;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpaction = InputSystem.actions.FindAction("Jump");
        trailRenderer = GetComponent<TrailRenderer>();
        isFacingRight = true;
        dashAction = InputSystem.actions.FindAction("Dash");

        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //dashInput = Input.GetButtonDown("Dash");
        PlayerInput();

      

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        Collider2D hit = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);
        if (hit != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }






    }
    

    void PlayerInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        Rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, Rb.linearVelocity.y);
        if (jumpaction.triggered && isGrounded)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, jumpForce);
        }


        if (jumpaction.WasPerformedThisFrame() && isGrounded || jumpaction.WasPerformedThisFrame() && coyoteTimeCounter > 0)
        {
            coyoteTimeCounter = 0;
            Rb.linearVelocityY = 0;
            Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (dashAction.WasPerformedThisFrame() && canDash)
        {

            isDashing = true;
            canDash = false;
            trailRenderer.emitting = true;
            dashDirection = new Vector2(transform.right.x, 0);
            if (dashDirection == Vector2.zero)
            {
                dashDirection = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            Rb.linearVelocity = dashDirection.normalized * dashingVelocity;
            return;
        }

        if (isGrounded)
        {
            canDash = true;
        }

        if (moveInput.x > 0)
        {
            isFacingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        if (moveInput.x < 0)
        {
            isFacingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TestEnemy"))
        {
            Rb.linearVelocityY = 0;
            Rb.AddForce(Vector2.up * jumpForce/2, ForceMode2D.Impulse);
        }
    }

    public void TakingDmg()
    {
        if (isInvincible) return;
        Invincibility();
    }

    IEnumerator Invincibility()
    {

        isInvincible = true;
        float invincibilityDuration = 2f;
        float blinkduration = 0.1f;

        Physics2D.IgnoreLayerCollision(7, 12, true);
        while (invincibilityDuration > 0)
        {

            Sprite.enabled = !Sprite.enabled;
            yield return new WaitForSeconds(blinkduration);
            invincibilityDuration -= blinkduration;
        }
        Physics2D.IgnoreLayerCollision(7, 12, false);
        Sprite.enabled = true;
        isInvincible = false;
    }

    IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;

    }
}
