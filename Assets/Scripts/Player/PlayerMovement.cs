using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Vector2 direction;
    public Vector2 Direction
    {
        get { return direction; }
    }
    
    private void Awake()
    {
        TryGetComponent(out rb);

        playerInput = new PlayerInput();

        playerInput.Player.Move.performed += ctx => direction = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled += _ => direction = Vector2.zero;
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * direction.x, speed * direction.y);
    }
}
