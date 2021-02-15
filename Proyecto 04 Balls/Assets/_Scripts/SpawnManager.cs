using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemiePrefabs;
    private float spawnRange = 9;
    private int indexPrefab;
    public int enemyCount;

    [SerializeField] private int enemiesForWave;
    [SerializeField] private int powerUpsForWave;

    [SerializeField] private float waitTimeSpawn;

    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Prefab index
        indexPrefab = Random.Range(0, EnemiePrefabs.Length);
        StartCoroutine(SpawnEnemyWave(enemiesForWave));
           
    }
    private void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            enemiesForWave++;
            StartCoroutine(SpawnEnemyWave(enemiesForWave));
            StartCoroutine(SpawnPowerUpWave(powerUpsForWave));
            powerUpsForWave = Random.Range(1, 4);
            
        }
    }


    /// <summary>
    /// Genera una posición aleatoria dentro de la zona de juego
    /// </summary>
    /// <returns>Devuelve una posición aleatoria de la zona de juego</returns>
    private Vector3 GenerateSpawnPosition()
    {
        //Random Position
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    /// <summary>
    /// Metodo que genera un número determinado de enemigos en pantalla
    /// <paramref name="numberOfEnemies"/> Número de enemigos a instanciar
    /// </summary>
    private IEnumerator SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            indexPrefab = Random.Range(0, EnemiePrefabs.Length);
            Instantiate(EnemiePrefabs[indexPrefab],
                    GenerateSpawnPosition(), EnemiePrefabs[indexPrefab].transform.rotation);
            yield return new WaitForSeconds(waitTimeSpawn);
        }
    }


    /// <summary>
    /// Metodo que genera un número determinado de power ups en pantalla
    /// </summary>
    /// <param name="numberOfPowerUps">Número de Power Ups a instanciar</param>
    private IEnumerator SpawnPowerUpWave(int numberOfPowerUps)
    {
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            yield return new WaitForSeconds(waitTimeSpawn*2);
        }
    }
}
