using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] cactus;

    public int Rand { get => Random.Range(0, 3); }

    private void Start()
    {
        StartCoroutine(obstacle());
        GameManager.Inst.Player.onDead += Stopcorutine;
    }

    IEnumerator obstacle()
    {
        while(true)
        {
        yield return new WaitForSeconds(2.0f);
        Instantiate(cactus[Rand], transform.position, Quaternion.identity);
        }
    }

    void Stopcorutine()
    {
        StopAllCoroutines();
    }
}
