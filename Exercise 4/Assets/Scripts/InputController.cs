using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    MovementController controller = new MovementController();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove()
    {
        // Get the latest value for the input from the Input System
        inputDirection = context.ReadValue<Vector2>();  // This is already normalized for us

        // Send that new direction to the Vehicle class
        myMovmentController.SetDirection(inputDirection);

    }
}
