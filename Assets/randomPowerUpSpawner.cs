using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class randomPowerUpSpawner : MonoBehaviour
{
    public float minXSpawn = -73f;
    public float maxXSpawn = 73f;
    public float minZSpawn = -30f;
    public float maxZSpawn = 26f;
    public float spawnInterval = 0.25f;
    //Shows how far a power up can spawn from the x and z axis (y axis isn't necessary since the characters can't jump)
    public List<GameObject> powerUpPrefabs;

    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }
    IEnumerator SpawnPowerUp() //IEnumerator ensures the code is ran multiple times, not just once.
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float randomX = Random.Range(minXSpawn, maxXSpawn);
            float randomZ = Random.Range(minZSpawn, maxZSpawn);
            Vector3 spawnPosition = new Vector3(randomX, -8f, randomZ);
            if (powerUpPrefabs.Count == 0)
            {
                continue;
            }
            int randomIndex = Random.Range(0, powerUpPrefabs.Count);
            Instantiate(powerUpPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}