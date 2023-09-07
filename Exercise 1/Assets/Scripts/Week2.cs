using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2 : MonoBehaviour
{
    [SerializeField]
    int health;

    [SerializeField]
    string creature_name = "Bob";

    [SerializeField]
    GameObject creaturePrefab;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        // Instantiate(creaturePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        ++health;
        Debug.Log($"Hi my name is {creature_name}");
    }

    private void Awake()
    {

    }

    private void OnEnable()
    {

    }
}
