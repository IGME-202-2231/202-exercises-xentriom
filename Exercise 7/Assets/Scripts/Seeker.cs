using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    // Target of seeker (fleer)
    [SerializeField] GameObject target;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Seek the target and teleport fleer if collision occurs
    /// </summary>
    protected override void CalcSteeringForces()
    {
        Vector3 seekForce = Seek(target);
        physicsObject.ApplyForce(seekForce);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(transform.position, physicsObject.Velocity + transform.position);
    }
}