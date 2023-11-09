using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        camSize = new Vector2(
            (2.0f * cam.orthographicSize) * cam.aspect,
            2.0f * cam.orthographicSize);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetPos"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetPos"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="time"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    protected Vector3 Wander(float time, float radius)
    {
        Vector3 targetPos = CalcFuturePosition(time);
        float randAngle = Random.Range(0, Mathf.PI * 2);

        targetPos.x += Mathf.Cos(randAngle) * radius;
        targetPos.y += Mathf.Sin(randAngle) * radius;

        return Seek(targetPos);
    }

    protected Vector3 StayInBounds()
    {
        if (transform.position.x <= -camSize.x / 2 + 1 ||
            transform.position.x >= camSize.x / 2 - 1 ||
            transform.position.y <= -camSize.y / 2 + 1 ||
            transform.position.y >= camSize.y / 2 - 1)
        {
            return Seek(Vector3.zero);
        }
        return Vector3.zero;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public Vector3 CalcFuturePosition(float time)
    {
        return physicsObject.Velocity * time + transform.position;
    }
}