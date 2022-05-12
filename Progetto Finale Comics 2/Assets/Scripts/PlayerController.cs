using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float jumpForce = 20;
    [SerializeField] float jumpRememberTime = 0.2f;
    [Range(0f, 1f)]
    [SerializeField] float cutJumpValue = 0.5f;
    //[SerializeField] float weightOnFalling = 10f;
    [Range(0f, 1f)]
    [SerializeField] float dampingValue = 0.5f;
    float jumpRememberTimer;

    [Header("Player Grounded Settings")]
    [SerializeField] Transform checkGround;
    [SerializeField] float groundCheckRadius = 0.3f;
    [SerializeField] float groundedRememberTime = 0.1f;
    [SerializeField] LayerMask groundLayer;
    float groundedRememberTimer;


    PlayerInput playerInput;
    Vector2 direction;
    Rigidbody2D rb;

    bool isGrounded;

    //Da togliere?
    //bool isFalling;
    //float acceleration = 10;
    //float deceleration = 10;
    //float currentSpeed = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        groundedRememberTimer -= Time.deltaTime;
        jumpRememberTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        CheckGround();
        Movement();
    }

    public void Movement()
    {
        direction = playerInput.Player.Movement.ReadValue<Vector2>();
        direction.y = 0;
        rb.velocity = new Vector2(GetHorizontalVelocity(), rb.velocity.y);

        //rb.velocity = new Vector2(direction.x * movementSpeed , rb.velocity.y);  
    }

    private float GetHorizontalVelocity()
    {
        float horizontal = rb.velocity.x;
        horizontal += direction.x;
        horizontal *= Mathf.Pow(1f - dampingValue, Time.deltaTime * 10f);
        return horizontal;
    }

    public void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        jumpRememberTimer = jumpRememberTime;
        if ((jumpRememberTimer > 0) && (groundedRememberTimer > 0))
        {
            jumpRememberTimer = 0;
            groundedRememberTimer = 0;

            //Altri modi per il salto:
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void AbortJump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * cutJumpValue);
        }
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
        playerInput.Player.Jump.performed += Jump;
        playerInput.Player.Jump.canceled += AbortJump;
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
