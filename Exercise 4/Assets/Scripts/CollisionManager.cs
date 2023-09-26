using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] List<SpriteInfo> colliables = new List<SpriteInfo>();

    // Update is called once per frame
    void Update()
    {
        // Loop through all object for collisions
        // When a collision change color
        foreach (var colliable in colliables)
        {
            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="spriteA"></param>
    /// <param name="spriteB"></param>
    /// <returns></returns>
    bool AABBCheck (SpriteInfo spriteA, SpriteInfo spriteB)
    {
        // Check for collision
        if(spriteB.RectMin.x < spriteA.RectMax.x &&
            spriteB.RectMax.x > spriteA.RectMin.x &&
            spriteB.RectMin.y < spriteA.RectMax.y &&
            spriteB.RectMax.y > spriteA.RectMin.y)
        {
            return true;
        }
        return false;
    }
}
