using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 5f;

    PlayerInput playerInput;
    Vector2 direction;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //rb.velocity = Vector2.up * jumpForce;  
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Movement()
    {
        direction = playerInput.Player.Movement.ReadValue<Vector2>();
        direction.y = 0;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
