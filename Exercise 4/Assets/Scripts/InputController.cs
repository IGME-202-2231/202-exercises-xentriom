using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    MovementController controller;

    public void OnMove(InputAction.CallbackContext context)
    {
        controller.Direction = context.ReadValue<Vector2>();
    }
}
