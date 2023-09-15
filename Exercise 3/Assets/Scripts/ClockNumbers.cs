using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    TextMesh clockNumber;

    [SerializeField]
    private float radius = 2.19f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 12; i++)
        {
            float angle = i * (360f / 12f) * Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * radius;
            float y = Mathf.Cos(angle) * radius;

            Vector3 position = new(x, y, 0f);
            TextMesh number = Instantiate(clockNumber, position, Quaternion.identity);
            number.text = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
