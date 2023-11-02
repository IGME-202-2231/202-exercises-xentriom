using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] GameObject target;

    protected override void CalcSteeringForces()
    {
        Vector3 seekForce = Seek(target);

        if (CircleCollision(physicsObject, target.GetComponent<PhysicsObject>()))
        {
            Debug.Log("Collision!");

            // Teleport the fleer to a random position in the world
            Vector3 randomPosition = new Vector3(Random.Range(-camSize.x / 2, camSize.x / 2), Random.Range(-camSize.y / 2, camSize.y / 2), 0f);
            target.transform.position = randomPosition;
        }

        physicsObject.ApplyForce(seekForce);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(transform.position, physicsObject.Velocity + transform.position);
    }

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