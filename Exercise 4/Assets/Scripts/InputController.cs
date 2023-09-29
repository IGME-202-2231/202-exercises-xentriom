using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Enum for collision type
/// </summary>
public enum CollisionType { AABB, Circle };

public class InputController : MonoBehaviour
{
    // Variable field
    [SerializeField] MovementController controller;
    CollisionType collision;

    /// <summary>
    /// Get the collision type
    /// </summary>
    public CollisionType Collision { get { return collision; } }

    // Update is called once per frame
    private void Update()
    {
        // Check to see if 'R' was pressed
        if (UnityEngine.InputSystem.Keyboard.current.rKey.wasPressedThisFrame)
        {
            // Change collision type
            if (collision == CollisionType.AABB)
            {
                collision = CollisionType.Circle;
            }
            else
            {
                collision = CollisionType.AABB;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        controller.SetDirection(context.ReadValue<Vector2>());
    }
}