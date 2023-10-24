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

    // Start is called before the first frame update
    void Start()
    {
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
}
