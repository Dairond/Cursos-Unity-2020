using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }
    public GameState gameState;
    
    public List<GameObject> targetPrefabs;
    private float spawnRate = 1;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
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

    public GameObject titleScreen;

    public int neutralScore;
    public int neutralCount;
    public int objectCount;
    

    /// <summary>
    /// Method that start the game
    /// </summary>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);

        spawnRate /= difficulty;
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
    /// <param name="scoreToAdd">The score to add to the actual score</param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        neutralScore += scoreToAdd;
        scoreText.text = "Score: " + Score;
        countText.text = "Count: " + objectCount;
    }

    public void GameOver()
    {
        gameState = GameState.gameOver;
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}