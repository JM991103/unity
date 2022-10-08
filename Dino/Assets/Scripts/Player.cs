using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInptAction playerInput;
    Rigidbody2D rigid;

    public float jumpHigh = 3.0f;       // ���� ����

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
        // velocity�� ���� Vector2.up(����) * jumpHigh(������)�� ���ؼ� �־��ش�.
        rigid.velocity = Vector2.up * jumpHigh;

        // AddForce = ������ٵ𿡰� ���� �������ִ� �Լ�
                            // ���� * ���� ��, ���� ����
        //rigid.AddForce(Vector2.up * jumpHigh, ForceMode2D.Impulse);
    }
}
