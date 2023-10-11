using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] SpriteRenderer animalPrefab;
    [SerializeField] List<Sprite> animalImages = new List<Sprite>();
    List<SpriteRenderer> spawnedAnimals = new List<SpriteRenderer>();
    private Vector2 range = new Vector2(10f, 100f);
    private float stdDev;
    private float mean;

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
        stdDev = Random.Range(1f, 4f);
    }

    public SpriteRenderer SpawnCreature()
    {
        return Instantiate(animalPrefab);
    }

    public void Spawn()
    {
        DestroyAnimal();

        for (int i = 0; i < Random.Range(range.x, range.y); i++)
        {
            spawnedAnimals.Add(SpawnCreature());

            // Do random stuff

            // Set color
            spawnedAnimals[i].color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            // Set position
            float meanRange = Random.Range(0, 10);
            if (meanRange >= 0f && meanRange <= 6f)
            {
                mean = 0f;
            }
            else if (meanRange == 7f || meanRange == 8f)
            {
                mean = -1f;
            }
            else
            {
                mean = 1f;
            }
            Vector2 spawnPosition = new Vector2(
                Gaussian(mean, stdDev),
                Gaussian(mean, stdDev));
            spawnedAnimals[i].transform.position = spawnPosition;

            // Picking random animal
            float randValue = Random.value;
            if (randValue < 0.10f)
            {
                spawnedAnimals[i].sprite = animalImages[2];
            }
            else if (randValue < 0.25f)
            {
                spawnedAnimals[i].sprite = animalImages[3];
            }
            else if (randValue < 0.45f)
            {
                spawnedAnimals[i].sprite = animalImages[4];
            }
            else if (randValue < 0.70)
            {
                spawnedAnimals[i].sprite = animalImages[0];
            }
            else
            {
                spawnedAnimals[i].sprite = animalImages[1];
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="std"></param>
    /// <returns></returns>
    float Gaussian(float mean, float std)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue = 
            Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * 
            Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + std * gaussValue;
    }

    /// <summary>
    /// 
    /// </summary>
    public void DestroyAnimal()
    {
        foreach (var animal in spawnedAnimals)
        {
            Destroy(animal.gameObject);
        }

        spawnedAnimals.Clear();
    }
}