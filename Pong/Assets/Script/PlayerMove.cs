using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    PlayerInputAction input;
    public float speed = 5.0f;
    Vector3 vec3;


    private void Awake()
    {
        input = new PlayerInputAction();
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * vec3);
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

    private void Onmove(InputAction.CallbackContext context)
    {
        vec3 = context.ReadValue<Vector2>();
    }

}
