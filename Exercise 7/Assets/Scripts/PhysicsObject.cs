using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 acceleration = Vector3.zero;
    [SerializeField] float mass = 1;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] bool useGravity = true;
    private Camera cam;
    private float camHeight;
    private float camWidth;
    private Vector2 screenMin;
    private Vector2 screenMax;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHeight = 2.0f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (useGravity)
        {
            ApplyGravity(Vector3.down * 9.8f);
        }

        // Calculate the velocity for this frame
        velocity += acceleration * Time.deltaTime;

        // Cap max velocity
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        CheckBounds();

        position += velocity * Time.deltaTime;

        // Grab current direction from velocity
        direction = velocity.normalized;

        transform.position = position;

        // Zero out acceleration
        acceleration = Vector3.zero;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    void ApplyGravity(Vector3 force)
    {
        acceleration += force;
    }

    void CheckBounds()
    {
        // Check left/right
       if (position.x <= screenMin.x)
       {
            velocity.x *= -1f;
            position.x = screenMin.x;
       }
       else if (position.x >= screenMax.x)
       {
            velocity.x *= -1f;
            position.x = screenMax.x;
        }

       // Check top/bottom
       if (position.y <= screenMin.y)
       {
            velocity.y *= -1f;
            position.x = screenMax.y;
       }
       else if (position.y >= screenMax.y)
       {
            velocity.y *= -1f;
            position.x = screenMin.y;
       }
    }
}
