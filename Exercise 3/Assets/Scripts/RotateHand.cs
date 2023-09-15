using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    private float turnAmount = -6;

    [SerializeField]
    bool useDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Switch between using deltaTime and not using deltaTime
        if (Input.GetKeyDown(KeyCode.R))
        {
            useDeltaTime = !useDeltaTime;
        }

        // Rotate the hand
        if (!useDeltaTime)
        {
            transform.Rotate(0f, 0f, turnAmount);
        }
        else
        {
            transform.Rotate(0f, 0f, turnAmount * Time.deltaTime);
        }
    }
}
