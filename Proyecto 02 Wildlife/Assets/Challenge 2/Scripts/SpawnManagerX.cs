using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    
    private float spawnInterval;

    private int spawnIndex;
    private float Counter;
    private float nextWaitTime = 5f;

    // Start is called before the first frame update
    
    private void Update()
    {
        Counter += Time.deltaTime;
        if (Counter >= nextWaitTime)
        {
            Counter = 0;
            nextWaitTime = Random.Range(2, 5);
            spawnInterval = nextWaitTime;
            Invoke("SpawnRandomBall", spawnInterval);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        spawnIndex = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[spawnIndex], spawnPos, ballPrefabs[spawnIndex].transform.rotation);
    }

}
