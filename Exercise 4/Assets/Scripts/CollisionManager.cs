using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum CollisionType { AABB, Circle };

public class CollisionManager : MonoBehaviour
{
    [SerializeField] List<SpriteInfo> colliables = new List<SpriteInfo>();
    [SerializeField] SpriteInfo sprite;
    private CollisionType collision = CollisionType.AABB;

    // Update is called once per frame
    void Update()
    {
        // Swap between the two mode 
        if (Keyboard.current[Key.R].isPressed)
        {
            if (collision == CollisionType.AABB) { collision = CollisionType.Circle; }
            if (collision == CollisionType.Circle) { collision = CollisionType.AABB; }
        }

        // AABB
        if (collision == CollisionType.AABB)
        {
            foreach (var colliable in colliables)
            {
                if (AABBCollision(sprite, colliable))
                {

                }
            }
        }

        // Cicle Collision
        if (collision == CollisionType.Circle)
        {
            foreach (var colliable in colliables)
            {
                if (CircleCollision(sprite, colliable))
                {

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
        if (Mathf.Pow((spriteB.RectMax.x / 2) - (spriteA.RectMax.x / 2), 2) + 
            Mathf.Pow((spriteB.RectMax.y / 2) - (spriteA.RectMax.y / 2), 2) <= 
            Mathf.Pow(spriteA.Radius + spriteB.Radius, 2))
        {
            return true;
        }
        return false;
    }
}
