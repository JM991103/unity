using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 7.0f;
    Vector3 dir;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * dir);
    }

    private void Start()
    {
        dir = Random.insideUnitCircle;
        dir = dir.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            dir = Vector3.Reflect(dir, collision.contacts[0].normal);
        }
    }
}
