using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movemens Settings")]
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float acceleration = 7;
    [SerializeField] float deceleration = 7;
    //float velPower = 1;

    [Header("Jump Settings")]
    [SerializeField] float jumpForce = 20;
    [Range(0f, 1f)]
    [SerializeField] float cutJumpValue = 0.5f;
    //[SerializeField] float airAcceleration = 3;
    //[SerializeField] float airDeceleration = 3;
    [SerializeField] float fallGravityMultiplier = 2.5f;
    [SerializeField] float gravityScale;
    float jumpRememberTime = 0.2f;
    float jumpRememberTimer;

    [Header("Grounded Settings")]
    [SerializeField] Transform checkGround;
    [SerializeField] float groundCheckRadius = 0.3f;
    [SerializeField] float groundedRememberTime = 0.1f;
    [SerializeField] LayerMask groundLayer;  
    float groundedRememberTimer;

    PlayerInput playerInput;
    Vector2 direction;
    Rigidbody2D rb;
    float horizontalMove;
    bool isGrounded;

    bool changingDirection => (rb.velocity.x > 0f && direction.x < 0f) || (rb.velocity.x < 0f && direction.x > 0f);

    //Da togliere?
    //[SerializeField] float weightOnFalling = 10f;
    //bool isFalling;
    //float currentSpeed = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    private void Update()
    {
        groundedRememberTimer -= Time.deltaTime;
        jumpRememberTimer -= Time.deltaTime;
        SetGravity();
    }

    void FixedUpdate()
    {
        CheckGround();
        Movement();
        
        //Friction();
    }

    private void SetGravity()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = gravityScale * fallGravityMultiplier;
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
    }

    //private void Friction()
    //{
    //    if(groundedRememberTimer > 0 && Mathf.Abs(direction.x) < 0.01f)
    //    {
    //        float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), frictionAmount);
    //        amount *= Mathf.Sign(rb.velocity.x);
    //        rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
    //    }
    //}

    public void Movement()
    {
        direction = playerInput.Player.Movement.ReadValue<Vector2>();
        direction.y = 0;


        //horizontalMove += direction.x * acceleration * Time.fixedDeltaTime;
        //horizontalMove = Mathf.Clamp(horizontalMove, -movementSpeed, movementSpeed);

        //horizontalMove = Mathf.MoveTowards(horizontalMove, 0, deceleration * Time.fixedDeltaTime);

        if (Mathf.Abs(direction.x) < 0.01f || changingDirection)
        {
            horizontalMove = Mathf.MoveTowards(horizontalMove, 0, deceleration * Time.fixedDeltaTime);
        }
        else
        {
            horizontalMove += direction.x * acceleration * Time.fixedDeltaTime;
            horizontalMove = Mathf.Clamp(horizontalMove, -movementSpeed, movementSpeed);
        }

        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        //float targetSpeed = direction.x * movementSpeed;
        //float speedDif = targetSpeed - rb.velocity.x;
        //float accelRate;
        //if (groundedRememberTime > 0)
        //{
        //    accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        //}
        //else
        //{
        //    accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration * airAcceleration : deceleration * airDeceleration;
        //}
        //float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        //rb.AddForce(movement * Vector2.right);

        //Altri modi per il movimento:
        //rb.velocity = new Vector2(ApplyDamping(), rb.velocity.y);
    }

    public void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if ((jumpRememberTimer > 0) && (groundedRememberTimer > 0))
        {
            jumpRememberTimer = 0;
            groundedRememberTimer = 0;

            rb.velocity = Vector2.up * jumpForce;

            //Altri modi per il salto:
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        }
    }

    private void AbortJump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * cutJumpValue);
        //rb.AddForce(Vector2.down * rb.velocity.y * (1f - cutJumpValue), ForceMode2D.Impulse);
        jumpRememberTimer = 0;
        groundedRememberTimer = 0;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            groundedRememberTimer = groundedRememberTime;
        }
    }

    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.Jump.started += SetJumpTimer;
        playerInput.Player.Jump.performed += Jump;
        playerInput.Player.Jump.canceled += AbortJump;
    }

    private void SetJumpTimer(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        jumpRememberTimer = jumpRememberTime;
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkGround.position, groundCheckRadius);
    }

    
}
