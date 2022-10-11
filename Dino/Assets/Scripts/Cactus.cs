using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    bool move = true;

    private void Start()
    {
        GameManager.Inst.Player.onDead += Move;
    }

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        move = false;
    }    
}
