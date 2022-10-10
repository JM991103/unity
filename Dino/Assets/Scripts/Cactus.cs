using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

}
