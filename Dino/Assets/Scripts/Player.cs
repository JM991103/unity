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

    public float jumpHigh = 7.0f;       // ���� ����
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
            // velocity�� ���� Vector2.up(����) * jumpHigh(������)�� ���ؼ� �־��ش�.
            rigid.velocity = Vector2.up * jumpHigh;

        }
        // AddForce = ������ٵ𿡰� ���� �������ִ� �Լ�
                            // ���� * ���� ��, ���� ����
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
