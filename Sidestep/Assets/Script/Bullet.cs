using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7.0f;
    public GameObject bullet;

    public bool Spawn = false;
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

}
