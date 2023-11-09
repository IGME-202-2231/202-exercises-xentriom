using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField][Range(0.1f, 5f)] float wanderTime;
    [SerializeField][Range(0.1f, 5f)] float wanderRadius;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void CalcSteeringForces()
    {
        physicsObject.ApplyForce(Wander(wanderTime, wanderRadius));
        physicsObject.ApplyForce(StayInBounds());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(CalcFuturePosition(wanderTime), wanderRadius);
    }
}
