using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInptAction playerInput;
    Rigidbody2D rigid;
    Animator anim;

    public float jumpHigh = 7.0f;       // 점프 높이
    bool jumpTime = true;

    public Action onDead;

    private void Awake()
    {
        playerInput = new PlayerInptAction();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (jumpTime)
        {
            jumpTime = false;
            anim.SetBool("Jump", true);
            // velocity의 값에 Vector2.up(높이) * jumpHigh(점프력)을 곱해서 넣어준다.
            rigid.velocity = Vector2.up * jumpHigh;

        }
        // AddForce = 리지드바디에게 힘을 전달해주는 함수
                            // 방향 * 힘의 값, 힘의 종류
        //rigid.AddForce(Vector2.up * jumpHigh, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!jumpTime)
        {
            jumpTime = true;
        }
        anim.SetBool("Jump", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        playerInput.PlayerInput.Disable();
        onDead?.Invoke();
        anim.SetBool("Die", true);
        GameManager.Inst.Save();
    }
}
