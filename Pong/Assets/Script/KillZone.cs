using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Action<bool> OnLifeDie;
    public Action<int> Upscore;
    public Action<int> UpScore1;
    int value = 0;
    int value1 = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        OnLifeDie?.Invoke(false);

        if (collision.transform.position.x > 0)
        {
            
            Upscore?.Invoke(++value);
        }
        if (collision.transform.position.x < 0)
        {
            UpScore1?.Invoke(++value1);
        }
    }


}
