using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movemens Settings")]
    [SerializeField] float movementSpeed = 10;
    [Range(0f, 1f)]
    [SerializeField] float movementDamping = 0.5f;
    [Range(0f, 1f)]
    [SerializeField] float stoppingDamping = 0.5f;
    [Range(0f, 1f)]
    [SerializeField] float turningDamping = 0.5f;

    [Header("Jump Settings")]
    [SerializeField] float jumpForce = 20;
    [Range(0f, 1f)]
    [SerializeField] float cutJumpValue = 0.5f;
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

    bool isGrounded;

    //Da togliere?
    //[SerializeField] float weightOnFalling = 10f;
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
        rb.velocity = new Vector2(ApplyDamping(), rb.velocity.y);

        //rb.velocity = new Vector2(direction.x * movementSpeed , rb.velocity.y);  
    }

    private float ApplyDamping()
    {
        float horizontal = rb.velocity.x;
        horizontal += direction.x;

        if (Mathf.Abs(direction.x) < 0.01f)
            horizontal *= Mathf.Pow(1f - stoppingDamping, Time.deltaTime * 10f);
        else if (Mathf.Sign(direction.x) != Mathf.Sign(horizontal))
            horizontal *= Mathf.Pow(1f - turningDamping, Time.deltaTime * 10f);
        else
            horizontal *= Mathf.Pow(1f - movementDamping, Time.deltaTime * 10f);

        return horizontal;
    }

    public void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
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
