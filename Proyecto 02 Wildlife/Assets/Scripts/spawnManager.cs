using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 15f;
    private float spawnPosZ;

    [SerializeField,Range(2,10)]private float startDelay = 2f;
    [SerializeField,Range(0.1f,3)]private float spawnInterval = 1.5f;

    private void Start()
    {
        spawnPosZ = transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }


    private void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        animalIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[animalIndex],
            spawnPos,
            enemies[animalIndex].transform.rotation);
    }
}
