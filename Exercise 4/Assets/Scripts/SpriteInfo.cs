using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField] float radius = 1f;
    [SerializeField] Vector2 rectSize = Vector2.one;
    [SerializeField] SpriteRenderer renderer;

    bool isColliding = false;

    /// <summary>
    /// 
    /// </summary>
    public float Radius { get { return radius; } }

    /// <summary>
    /// 
    /// </summary>
    public bool IsColliding { set { isColliding = value; } }

    /// <summary>
    /// Bottom left
    /// </summary>
    public Vector2 RectMin
    {
        get 
        { 
            return new Vector2(
                transform.position.x - (rectSize.x / 2f), 
                transform.position.y - (rectSize.y / 2f)); 
        }
    }

    /// <summary>
    /// Top right
    /// </summary>
    public Vector2 RectMax
    {
        get 
        { 
            return new Vector2(
                transform.position.x + (rectSize.x / 2f), 
                transform.position.y + (rectSize.y / 2f)); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If colliding turn sprite red
        if (isColliding)
        {
            renderer.color = Color.red;
        }
        else
        {
            renderer.color = Color.white;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireCube(transform.position, rectSize);
    }
}
