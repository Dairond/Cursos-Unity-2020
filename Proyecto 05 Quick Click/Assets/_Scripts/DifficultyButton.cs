using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _difButton;
    private GameManager gameManager;
    private int Difficulty;

    public int difficulty{ get => Difficulty; }

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
            Difficulty = 1;
        }
        else if (selectedDifficulty==DifficultyLevels.medium)
        {
            Difficulty = 2;
        }
        else if (selectedDifficulty==DifficultyLevels.hard)
        {
            Difficulty = 3;
        }
    }

    
    void SetDifficulty()
    {
        gameManager.StartGame(Difficulty);
    }
}
