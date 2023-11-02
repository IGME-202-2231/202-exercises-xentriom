using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class Agent : MonoBehaviour
{
    // Physics object of the agent and max force
    [SerializeField] protected PhysicsObject physicsObject;
    [SerializeField] protected float maxForce = 10;

    // Camera and camera size
    protected Camera cam;
    protected Vector2 camSize;

    // Start is called before the first frame update
    void Start()
    {
        // Get the camera and determine camera size
        cam = Camera.main;
        camSize = new Vector2(
            (2.0f * cam.orthographicSize) * cam.aspect, 
            2.0f * cam.orthographicSize); 
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CalcSteeringForces();
    }

    protected abstract void CalcSteeringForces();

    protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }

    protected Vector3 Flee(GameObject target)
    {
        return Flee(target.transform.position);
    }

    protected Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.MaxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;

        // Return seek steering force
        return seekingForce;
    }
    protected Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = transform.position - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.MaxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;

        // Return seek steering force
        return seekingForce;
    }
}