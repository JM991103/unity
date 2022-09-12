using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpwaner : MonoBehaviour
{
    public GameObject Ball;

    private void Awake()
    {
        Ball = new GameObject();
    }

    private void Start()
    {
        GameObject obj = Instantiate(Ball, transform.position, Quaternion.identity);
        obj.transform.Translate(0, Random.Range(4.5f, -4.5f), 0);

    }

}
