using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;

    [SerializeField]
    float speed = 1.0f;

    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    public Vector3 Direction 
    { 
        get { return direction; }
        set { if (direction != null) { direction = value.normalized; } }
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        objectPosition += velocity;

        // Check for OB


        transform.position = objectPosition;
    }
}