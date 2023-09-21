using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Camera cameraObject = Camera.main;

    Vector3 objectPosition = Vector3.zero;

    [SerializeField]
    float speed = 1.0f;

    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;

        float totalCamHeight = cameraObject.orthographicSize * 2f;
        float totalCamWidth = totalCamHeight * cameraObject.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        objectPosition += velocity;

        // Check for OB


        transform.position = objectPosition;
    }

    public void SetDirection(Vector3 newDirection)
    {
        if (newDirection != null)
        {
            direction = newDirection.normalized;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
            }
        }
    }
}