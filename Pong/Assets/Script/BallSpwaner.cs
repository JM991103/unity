using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpwaner : MonoBehaviour
{
    public GameObject BallPrefab;
    bool isDead = false;

    IEnumerator BallSpawn;

    float minY = -3.8f;
    float maxY = 3.8f;

    private void Awake()
    {
        BallSpawn = ballSpawner();
    }

    private void Start()
    {
        StartCoroutine(BallSpawn);
        KillZone kill = GameObject.FindObjectOfType<KillZone>();
        kill.OnLifeDie += falseDead;
    }

    IEnumerator ballSpawner()
    {
        while (true)
        {

            if (!isDead)
            {
                GameObject obj = Instantiate(BallPrefab, transform.position, Quaternion.identity);
                obj.transform.Translate(0.0f, UnityEngine.Random.Range(minY, maxY), 0.0f);
                isDead = true;
            }
            yield return new WaitForSeconds(3.0f);
        }
    }

    void falseDead(bool value)
    {
        isDead = value;
    }
}
