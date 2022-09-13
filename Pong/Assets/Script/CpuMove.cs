using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CpuMove : PlayerMove
{

    private void OnEnable()
    {
        input.PlayerInput.Enable();
        input.PlayerInput.cpu.performed += Onmove; 
        input.PlayerInput.cpu.canceled += Onmove;
    }

    private void OnDisable()
    {
        input.PlayerInput.cpu.performed -= Onmove;
        input.PlayerInput.cpu.canceled -= Onmove;
        input.PlayerInput.Disable();
    }

    protected override void Onmove(InputAction.CallbackContext context)
    {
        base.Onmove(context);
    }
}
