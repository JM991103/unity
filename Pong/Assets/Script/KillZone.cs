using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Action<bool> OnLifeDie;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        OnLifeDie?.Invoke(false);
    }


}
