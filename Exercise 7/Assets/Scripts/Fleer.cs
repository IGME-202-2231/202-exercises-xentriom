using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    [SerializeField] GameObject target;

    protected override void CalcSteeringForces()
    {
        physicsObject.ApplyForce(Flee(target));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(transform.position, physicsObject.Velocity + transform.position);
    }
}
