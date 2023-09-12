using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    [SerializeField]
    private float turnAmount = 0;

    [SerializeField]
    bool useDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotateAmount;

        if (!useDeltaTime)
        {
            --turnAmount;
            rotateAmount = Quaternion.Euler(0f, 0f, turnAmount);
            transform.rotation = rotateAmount;
        }
        else
        {
            --turnAmount;
            rotateAmount = Quaternion.Euler(0f, 0f, turnAmount * Time.deltaTime);
            transform.rotation = rotateAmount;
        }
    }
}
