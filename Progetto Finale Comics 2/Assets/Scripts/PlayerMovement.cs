using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float speed = 10;

    PlayerInput playerInput;
    Vector2 direction;
    Rigidbody2D rbody;

    void Awake()
    {
        playerInput = new PlayerInput();
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        direction = playerInput.Player.Movement.ReadValue<Vector2>();
        direction.y = 0;
        //rbody.velocity = direction * speed;
        rbody.MovePosition((Vector2)transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
