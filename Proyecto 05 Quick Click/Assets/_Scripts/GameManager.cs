using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    private float spawnRate = 1;

    public TextMeshProUGUI scoreText;
    private int _score;
    private int Score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 9999999);
        }
        get
        {
            return _score;
        }
    }

    public int neutralScore;
    public int neutralCount;
    public int objectCount;
    void Start()
    {
        StartCoroutine(SpawnTarget());

        Score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    /// <summary>
    /// Update the score and show it on screen 
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        neutralScore += scoreToAdd;
        scoreText.text = "Score: " + Score;
    }
}