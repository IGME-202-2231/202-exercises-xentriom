using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    TextMesh clockNumber;

    [SerializeField]
    List<TextMesh> clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = new List<TextMesh>(12)
        {
            clockNumber
        };
    }

    // Update is called once per frame
    void Update()
    {
        float degrees = 0f;
        for (int i = 3; i < 15; i++)
        {
            Instantiate(clockNumber, new Vector3(0f, degrees, 0f), Quaternion.identity);
            degrees += 30;
        }
    }
}
