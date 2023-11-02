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
    [SerializeField][Range(0, 10)] int maxSpeed;

    [SerializeField] bool useGravity = true;
    [SerializeField] bool useFriction;

    private Camera cam;
    private float camHeight;
    private float camWidth;

    [SerializeField] float radius;

    public float Radius { get { return radius; } }
    public Vector3 Velocity { get { return velocity; } }

    public int MaxSpeed { get { return maxSpeed; } }

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
            ApplyGravity(Vector3.down * 1f);
        }
        if (useFriction)
        {
            ApplyFriction(0.8f);
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

    public void ApplyFriction(float coefficient)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction *= coefficient;
        ApplyForce(friction);
    }

    void CheckBounds()
    {
        // X Checks
        if (position.x <= -camWidth / 2)
        {
            velocity.x *= -1;
            position.x = -camWidth / 2;
        }
        else if (position.x >= camWidth / 2)
        {
            velocity.x *= -1;
            position.x = camWidth / 2;
        }

        // Y Checks
        if (position.y <= -camHeight / 2 + .5f)
        {
            velocity.y *= -1;
            position.y = -camHeight / 2 + .5f;
        }
        else if (position.y >= camHeight / 2)
        {
            velocity.y *= -1;
            position.y = camHeight / 2;
        }
    }
}