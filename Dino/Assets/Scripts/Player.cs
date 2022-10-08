using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInptAction playerInput;
    Rigidbody2D rigid;

    public float jumpHigh = 3.0f;       // 점프 높이

    private void Awake()
    {
        playerInput = new PlayerInptAction();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.PlayerInput.Enable();
        playerInput.PlayerInput.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        playerInput.PlayerInput.Jump.performed -= OnJump;
        playerInput.PlayerInput.Disable();
    }

    private void OnJump(InputAction.CallbackContext _)
    {
        // velocity의 값에 Vector2.up(높이) * jumpHigh(점프력)을 곱해서 넣어준다.
        rigid.velocity = Vector2.up * jumpHigh;

        // AddForce = 리지드바디에게 힘을 전달해주는 함수
                            // 방향 * 힘의 값, 힘의 종류
        //rigid.AddForce(Vector2.up * jumpHigh, ForceMode2D.Impulse);
    }
}
