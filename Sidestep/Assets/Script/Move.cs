using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 0.1f;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (speed * Time.deltaTime * dir);
    }


    void MoveInput(InputAction.CallbackContext context)
    {
        Vector2 InputDir = context.ReadValue<Vector2>();
        Debug.Log(InputDir);
        dir = InputDir;
       
    }
}
