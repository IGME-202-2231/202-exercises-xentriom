using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpt : MonoBehaviour
{
    [SerializeField] 
    int health;

    [SerializeField] 
    string name = "Bob";

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
        Debug.Log($"Hi my name is {name}");
    }

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
