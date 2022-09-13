using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    protected PlayerInputAction input;
    public float speed = 5.0f;
    Vector3 vec3;
    Rigidbody2D rigid;


    private void Awake()
    {
        input = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(transform.position + speed * Time.fixedDeltaTime * vec3);
    }

    private void OnEnable()
    {
        input.PlayerInput.Enable();
        input.PlayerInput.Move.performed += Onmove;
        input.PlayerInput.Move.canceled += Onmove;
    }

    private void OnDisable()
    {
        input.PlayerInput.Move.performed -= Onmove;
        input.PlayerInput.Move.canceled -= Onmove;
        input .PlayerInput.Disable();
    }

    protected virtual void Onmove(InputAction.CallbackContext context)
    {
        vec3 = context.ReadValue<Vector2>();
    }

}
