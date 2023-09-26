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
    /// 
    /// </summary>
    public Vector2 RectMin
    {
        get { return new Vector2(0,0); }
    }

    /// <summary>
    /// 
    /// </summary>
    public Vector2 RectMax
    {
        get { return rectSize; }
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
}
