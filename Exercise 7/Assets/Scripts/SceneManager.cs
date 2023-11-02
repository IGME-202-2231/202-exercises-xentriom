using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    [SerializeField] List<PhysicsObject> objects;
    Vector3 mousePosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0;

        foreach (var obj in objects)
        {
            obj.ApplyForce(mousePosition - obj.transform.position);
        }
    }
}