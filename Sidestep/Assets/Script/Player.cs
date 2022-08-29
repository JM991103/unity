using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInput InputActions;

    public float speed = 1.0f;
    Vector3 dir;

    Rigidbody2D rigid;
    Animator anim; 

    private void Awake()
    {
        InputActions = new PlayerInput();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        InputActions.player.Enable();
        InputActions.player.Move.performed += OnMove;
        InputActions.player.Move.canceled += OnMove;
    }



    private void OnDisable()
    {
        InputActions.player.Move.performed -= OnMove;
        InputActions.player.Move.canceled -= OnMove;
        InputActions.player.Disable();
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(transform.position + speed * dir * Time.fixedDeltaTime);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
        //Debug.Log("움직임");
        anim.SetFloat("InputX", dir.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Game Over");
    }
}
