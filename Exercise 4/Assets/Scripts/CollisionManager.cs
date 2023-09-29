using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    // Variable field
    [SerializeField] InputController inputController;
    [SerializeField] List<SpriteInfo> collectibles = new List<SpriteInfo>();
    [SerializeField] SpriteInfo vehicle;

    // Update is called once per frame
    void Update()
    {
        // AABB
        if (inputController.Collision == CollisionType.AABB)
        {
            foreach (var collectable in collectibles)
            {
                if (AABBCollision(vehicle, collectable))
                {
                    vehicle.IsColliding = true;
                    collectable.IsColliding = true;
                }
                else
                {
                    vehicle.IsColliding = false;
                    collectable.IsColliding = false;
                }
            }
        }

        // Cicle Collision
        if (inputController.Collision == CollisionType.Circle)
        {
            foreach (var collectable in collectibles)
            {
                if (CircleCollision(vehicle, collectable))
                {
                    vehicle.IsColliding = true;
                    collectable.IsColliding = true;
                }
                else
                {
                    vehicle.IsColliding = false;
                    collectable.IsColliding = false;
                }
            }
        }
    }

    /// <summary>
    /// Check if collision is true/false via AABB collision
    /// </summary>
    /// <param name="spriteA">The first sprite</param>
    /// <param name="spriteB">The second sprite</param>
    /// <returns>True if the sprites collide</returns>
    bool AABBCollision (SpriteInfo spriteA, SpriteInfo spriteB)
    {
        if (spriteB.RectMin.x < spriteA.RectMax.x &&
            spriteB.RectMax.x > spriteA.RectMin.x &&
            spriteB.RectMin.y < spriteA.RectMax.y &&
            spriteB.RectMax.y > spriteA.RectMin.y)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Check if collision is true/false via circle to circle collision
    /// </summary>
    /// <param name="spriteA">The first sprite</param>
    /// <param name="spriteB">The second sprite</param>
    /// <returns>True if the sprites collide</returns>
    bool CircleCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        Vector2 aCenter = new (spriteA.transform.position.x, spriteA.transform.position.y);
        Vector2 bCenter = new (spriteB.transform.position.x, spriteB.transform.position.y);

        if (Mathf.Pow(bCenter.x - aCenter.x, 2) + Mathf.Pow(bCenter.y - aCenter.y, 2) < 
            Mathf.Pow(spriteA.Radius + spriteB.Radius, 2))
        {
            return true;
        }
        return false;
    }
}
