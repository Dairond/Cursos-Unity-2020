using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private Vector3 spawnPos;
    private float startDelay = 5;
    private float reapeatDelay = 3;



    private playerController _playerController;
    void Start()
    {

        spawnPos = this.transform.position;
        InvokeRepeating("spawnObstacles", startDelay, reapeatDelay);

        _playerController = GameObject.Find("Player")
            .GetComponent<playerController>();

    }


    void spawnObstacles()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos,
                obstaclePrefab.transform.rotation);
        }
    }
}
