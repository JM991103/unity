using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwan : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(Random.Range(-8.5f, 8.5f), 10.0f, 0.0f);

        if (Random.Range(0.0f, 1.0f) < 0.03f)
        {
            Instantiate(bullet, transform.position = new Vector3(Random.Range(-8.5f, 8.5f), 10.0f, 0.0f)
, Quaternion.identity);
        }
    }
    
}
