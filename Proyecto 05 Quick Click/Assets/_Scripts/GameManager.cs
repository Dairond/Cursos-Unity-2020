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
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI finalScoreText;
    public Button retryButton;
    public int secondsCount;
    public int minutesCount;
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

    private int finalScore;

    public GameObject titleScreen;
    public GameObject inGameScreen;
    public GameObject gameOverScreen;
    private DifficultyButton difficultyButton;

    private const string MAX_SCORE = "Max_Score";

    private int numberOfLives = 3;
    public List<GameObject> lives;

    public int gameDifficulty;

    public int neutralScore;
    public int neutralCount;
    public int objectCount;
    
    private void Start()
    {
        ShowMaxScore();

        difficultyButton = FindObjectOfType<DifficultyButton>();
    }

    /// <summary>
    /// Method that start the game
    /// </summary>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        StartCoroutine(TimeCount());
        titleScreen.gameObject.SetActive(false);
        inGameScreen.gameObject.SetActive(true);

        gameDifficulty = difficulty;
        spawnRate /= difficulty;
        numberOfLives -= difficulty - 1;

        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }

        StartCoroutine(SpawnTarget());

        Score = 0;
        UpdateScore(0);
    }
    
    /// <summary>
    /// Spawn the targets in radom positions
    /// </summary>
    /// <returns>the spawn rate</returns>
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
    
    /// <summary>
    /// Shows the maximun score on screen
    /// </summary>
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE,0);
        scoreText.text = "Max Score: " + maxScore;
    }
    
    /// <summary>
    /// Set the maximun score reached in a variable
    /// </summary>
    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE,0);
        if(Score>maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, Score);
            //TODO:if there is a new max score, fire fireworks
        }
    }

    private void SetFinalScore()
    {
        finalScore = Score * ((secondsCount + (minutesCount * 60))*gameDifficulty);
        finalScoreText.text = "Final Score: \n" + finalScore;
    }

    /// <summary>
    /// Make the game enter in state of Game Over
    /// </summary>
    public void GameOver()
    {
        numberOfLives--;
        
        if (numberOfLives>=0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        
        

        if (numberOfLives == 0)
        {
            SetMaxScore();
            
            gameState = GameState.gameOver;
            gameOverScreen.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
        }
    }
    
    /// <summary>
    /// Restart the game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Count time in seconds and minutes
    /// </summary>
    /// <returns>One second wait</returns>
    IEnumerator TimeCount()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(1);
            secondsCount++;
            if (secondsCount == 60)
            {
                secondsCount = 0;
                minutesCount++;
            }

            if (secondsCount < 10)
            {
                timeText.text = "Time \n" + minutesCount + ":0" + secondsCount;
            }
            else
            {
                timeText.text = "Time \n" + minutesCount + ":" + secondsCount;
            }
        }
    }
}