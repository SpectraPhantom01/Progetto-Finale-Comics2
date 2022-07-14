using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//public enum PlayerState { Normal, Exposion }

public class PlayerController : MonoBehaviour
{
    [Header("Movemens Settings")]
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float acceleration = 7;
    [SerializeField] float deceleration = 7;
    float movementModifier = 1;
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

    [Header("Animator Settings")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer flipDirection;

    [Header("Explosion Settings")]
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] float radius;
    [SerializeField] float offsetExplosion;
    //[SerializeField] Vector2 direction;
    [SerializeField] float distance;
    //[SerializeField] UnityEvent preparation;
    //[SerializeField] UnityEvent endPreparation;
    [SerializeField] UnityEvent fade;

    PlayerInput playerInput;
    Vector2 direction;
    Rigidbody2D rb;
    Collider2D playerCollider;
    float horizontalMove;
    bool isGrounded;
    bool prepExplosion;
    [HideInInspector] public bool isDead;
    //PlayerState state;

    //Rigidbody2D rbPlatform;
    //bool isOnPlatform;

    bool changingDirection => (rb.velocity.x > 0f && direction.x < 0f) || (rb.velocity.x < 0f && direction.x > 0f);

    //Da togliere?
    //[SerializeField] float weightOnFalling = 10f;
    //bool isFalling;
    //float currentSpeed = 0;

    void Awake()
    {
        playerInput = new PlayerInput();

        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        gravityScale = rb.gravityScale;
    }

    private void Update()
    {
        groundedRememberTimer -= Time.deltaTime;
        jumpRememberTimer -= Time.deltaTime;

        //switch (state)
        //{
        //    case PlayerState.Normal:
                CheckGround();
                Movement();

                //ExplosionReduction(); /*--> Lerp in aria durante l'esplosione*/       

                SetGravity();
                AnimationSet();
        //        break;
        //    //case PlayerState.Exposion:
        //    //    break;
        //}

        

        //if (isOnPlatform)
        //{
        //    rb.velocity += rbPlatform.GetComponent<Traslator>().deltaMovement * 50;
        //}
    }

    private void AnimationSet()
    {
        if (rb.velocity.x < 0)
        {
            flipDirection.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            flipDirection.flipX = false;
        }
        animator.SetFloat("X Velocity", Math.Abs(rb.velocity.x));

        float yClamped = Mathf.Clamp(rb.velocity.y, -1, 1);
        
        animator.SetFloat("Y Velocity", (yClamped + 1) / 2);
        animator.SetBool("isGrounded", isGrounded);
    }

    void FixedUpdate()
    {
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

        if (Mathf.Abs(direction.x) < 0.01f || changingDirection)
        {
            horizontalMove = Mathf.MoveTowards(horizontalMove, 0, deceleration * Time.deltaTime);
        }
        else
        {
            horizontalMove += direction.x * acceleration * Time.deltaTime;
            horizontalMove = Mathf.Clamp(horizontalMove, -movementSpeed, movementSpeed);
        }

        //rb.velocity = new Vector2(horizontalMove * movementModifier, rb.velocity.y);
        rb.velocity = new Vector2(horizontalMove * movementModifier, ExplosionReduction());

    }

    private float ExplosionReduction()
    {
        if (prepExplosion)
        {
            return Mathf.Lerp(rb.velocity.y, 0, Time.deltaTime * 25);
        }
        return rb.velocity.y;
    }

    public void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if ((jumpRememberTimer > 0) && (groundedRememberTimer > 0))
        {
            jumpRememberTimer = 0;
            groundedRememberTimer = 0;

            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.Play("Jump");
            
        }
        //animator.SetBool("isGrounded", false);
    }

    private void AbortJump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * cutJumpValue);
        jumpRememberTimer = 0;
        groundedRememberTimer = 0;
        //animator.SetBool("isGrounded", false);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            groundedRememberTimer = groundedRememberTime;          
        }
    }

    private void SetJumpTimer(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        jumpRememberTimer = jumpRememberTime;
    }

    private void PlayerExplosion(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        prepExplosion = true;
        animator.SetTrigger("Explosion");
    }

    public void SetExplosion() 
    {
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        transform.parent = null;

        GetComponentInChildren<SpriteRenderer>().enabled = false;

        GameObject explosion = Instantiate(prefabExplosion, (Vector2)transform.position + new Vector2(0, offsetExplosion), transform.rotation);
        explosion.GetComponent<ExplosionBehaviour>().InitializeExplosion(offsetExplosion, radius, distance, fade);
        prepExplosion = false;
    }

    public void SetMovementModifier(float modifier)
    {
        movementModifier = modifier;
    }

    public void OnEnable()
    {
        playerInput.Player.Enable();

        playerInput.Player.Jump.started += SetJumpTimer;
        playerInput.Player.Jump.performed += Jump;
        playerInput.Player.Jump.canceled += AbortJump;
        playerInput.Player.Explosion.performed += PlayerExplosion;

        playerInput.Player.Pause.started += Pause;

        GetComponentInChildren<SpriteRenderer>().enabled = true;
        isDead = false;

        rb.bodyType = RigidbodyType2D.Dynamic;
        //playerCollider.enabled = true;

        //state = PlayerState.Normal;
    }

    private void Pause(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        PauseMenu.instance.CheckPauseMenu();
    }

    public void OnDisable()
    {
        playerInput.Player.Disable();

        //rb.bodyType = RigidbodyType2D.Static;
        //playerCollider.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkGround.position, groundCheckRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, offsetExplosion), radius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, distance), radius);
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.GetComponent<Traslator>() != null)
    //    {
    //        rbPlatform = collision.gameObject.GetComponent<Rigidbody2D>();
    //        isOnPlatform = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<Traslator>() != null)
    //    {
    //        rbPlatform = null;
    //        isOnPlatform = false;
    //    }
    //}


}
