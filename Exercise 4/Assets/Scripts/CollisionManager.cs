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
    /// 
    /// </summary>
    /// <param name="spriteA"></param>
    /// <param name="spriteB"></param>
    /// <returns></returns>
    bool AABBCollision (SpriteInfo spriteA, SpriteInfo spriteB)
    {
        // Check for collision
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
    /// 
    /// </summary>
    /// <param name="spriteA"></param>
    /// <param name="spriteB"></param>
    /// <returns></returns>
    bool CircleCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        if (spriteA.Radius + spriteB.Radius < 9)
        {
            return true;
        }
        return false;
    }
}
