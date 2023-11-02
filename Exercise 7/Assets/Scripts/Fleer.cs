using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    // Target of seeker (fleer)
    [SerializeField] GameObject target;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (CircleCollision(physicsObject, target.GetComponent<PhysicsObject>()))
        {
            Debug.Log("Collision!");

            // Teleport the fleer to a random position in the world
            Vector3 randomPosition = new Vector3(
                Random.Range(-camSize.x / 2, camSize.x / 2), 
                Random.Range(-camSize.y / 2, camSize.y / 2), 
                0f);
            transform.position = randomPosition;
        }
    }

    /// <summary>
    /// Calculate the flee steering force
    /// </summary>
    protected override void CalcSteeringForces()
    {
        physicsObject.ApplyForce(Flee(target));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(transform.position, physicsObject.Velocity + transform.position);
    }

    /// <summary>
    /// Check if two sprites are colliding
    /// </summary>
    /// <param name="spriteA">The first sprite</param>
    /// <param name="spriteB">The second sprite</param>
    /// <returns>True if they collide</returns>
    bool CircleCollision(PhysicsObject spriteA, PhysicsObject spriteB)
    {
        Vector2 aCenter = new(spriteA.transform.position.x, spriteA.transform.position.y);
        Vector2 bCenter = new(spriteB.transform.position.x, spriteB.transform.position.y);

        if (Mathf.Pow(bCenter.x - aCenter.x, 2) + Mathf.Pow(bCenter.y - aCenter.y, 2) <
            Mathf.Pow(spriteA.Radius + spriteB.Radius, 2))
        {
            return true;
        }
        return false;
    }
}
