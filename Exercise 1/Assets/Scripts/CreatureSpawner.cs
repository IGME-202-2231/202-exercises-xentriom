using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject creaturePrefab;

    [SerializeField]
    string creatureName = "Araxenty";

    [SerializeField]
    List<Vector3> spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize spawnLocation and add 3 locations
        spawnLocation = new List<Vector3>(3)
        {
            new Vector3(0, 0, 10),
            new Vector3(0, 0, 20),
            new Vector3(0, 0, 30)
        };

        // Instantiate each prefab
        foreach (var cord in spawnLocation)
        {
            Instantiate(creaturePrefab, new Vector3(cord.x, cord.y, cord.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
