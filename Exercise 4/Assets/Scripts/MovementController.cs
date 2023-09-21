using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Where is the vehicle
    Vector3 objectPosition = new Vector3(0, 0, 0);

    // How fast it should move in units per second
    float speed = 4f;

    // Direction vehicle is facing, must be normalized
    Vector3 direction = new Vector3(1, 0, 0);   // or Vector3.right

    // The delta in position for a single frame
    Vector3 velocity = new Vector3(0, 0, 0);   // or Vector3.zero

    // Start is called before the first frame update
    void Start()
    {
        // Grab the GameObject’s starting position
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        objectPosition += velocity;

        // Validate new calculated position

        // “Draw” this vehicle at that position
        transform.position = objectPosition;
    }
}
