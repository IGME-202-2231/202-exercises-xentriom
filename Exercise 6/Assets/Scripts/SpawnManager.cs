using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] SpriteRenderer animalPrefab;
    [SerializeField] List<Sprite> animalImages = new List<Sprite>();
    List<SpriteRenderer> spawnedAnimals = new List<SpriteRenderer>();
    float stdDev = 1f;

    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SpriteRenderer SpawnCreature()
    {
        return Instantiate(animalPrefab);
    }

    public void Spawn()
    {
        DestroyAnimal();

        for (int i = 0; i < 10; i++)
        {
            spawnedAnimals.Add(SpawnCreature());

            // Do random stuff

            // Set color
            spawnedAnimals[i].color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            // Set position
            Vector2 spawnPosition = new Vector2(
                Gaussian(0, stdDev),
                Gaussian(0, stdDev));
            spawnedAnimals[i].transform.position = spawnPosition;

            // Picking random animal
            float randValue = Random.value;
            if (randValue < 0.6f)
            {
                spawnedAnimals[i].sprite = animalImages[0];
            }
            else if (randValue < 0.84)
            {
                spawnedAnimals[i].sprite = animalImages[3];
            }
            else
            {
                spawnedAnimals[i].sprite = animalImages[2];
            }
        }
    }

    float Gaussian(float mean, float std)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue = 
            Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * 
            Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + std * gaussValue;
    }

    public void DestroyAnimal()
    {
        foreach (var animal in spawnedAnimals)
        {
            Destroy(animal.gameObject);
        }

        spawnedAnimals.Clear();
    }
}