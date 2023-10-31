using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] GameObject target;

    protected override void CalcSteeringForces()
    {
        physicsObject.ApplyForce(Seek(target));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(transform.position, physicsObject.Velocity + transform.position);
    }
}