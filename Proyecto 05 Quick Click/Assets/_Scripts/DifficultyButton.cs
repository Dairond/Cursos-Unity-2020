using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _difButton;
    private GameManager gameManager;
    private int difficulty;
    
    public enum DifficultyLevels
    {
        easy,
        medium,
        hard
    }
    public DifficultyLevels selectedDifficulty;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _difButton = GetComponent<Button>();
        _difButton.onClick.AddListener(SetDifficulty);
        if(selectedDifficulty==DifficultyLevels.easy)
        {
            difficulty = 1;
        }
        else if (selectedDifficulty==DifficultyLevels.medium)
        {
            difficulty = 2;
        }
        else if (selectedDifficulty==DifficultyLevels.hard)
        {
            difficulty = 3;
        }
    }

    
    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
