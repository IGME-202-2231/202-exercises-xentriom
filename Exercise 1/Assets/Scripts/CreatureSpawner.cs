using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject creaturePrefab;

    [SerializeField]
    List<Vector3> spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize spawnLocation and add 3 locations
        spawnLocation = new List<Vector3>(3)
        {
            new Vector3(0f, 0f, 5f),
            new Vector3(1.7f, -1.088f, 3.16f),
            new Vector3(12.26f, 0f, -1.82f)
        };

        // Instantiate each prefab
        for (int i = 0; i < spawnLocation.Count; i++)
        {
            switch (i)
            {
                case 0:
                    Instantiate(
                        creaturePrefab, 
                        new Vector3(
                            spawnLocation[i].x,
                            spawnLocation[i].y,
                            spawnLocation[i].z), 
                        Quaternion.Euler(0f, 98.411f, 0f));
                    break;
                case 1:
                    Instantiate(
                        creaturePrefab,
                        new Vector3(
                            spawnLocation[i].x,
                            spawnLocation[i].y,
                            spawnLocation[i].z),
                        Quaternion.Euler(0f, -30f, -270f));
                    break;
                case 2:
                    Instantiate(
                        creaturePrefab,
                        new Vector3(
                            spawnLocation[i].x,
                            spawnLocation[i].y,
                            spawnLocation[i].z),
                        Quaternion.identity);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
