using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralPowers : MonoBehaviour
{
    
    private GameManager gameManager;
    
    private int minType;
    private int maxType;

    private int neutralValue;
    public int neutralEffect = 2;

    [Range(1,3)]
    public int neutralType;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }
    
    public void NeutralHabilities()
    {
        if (gameManager.neutralCount > 0 & (gameManager.neutralScore > 0 | gameManager.neutralScore < 0))
            {
                float neutralMulti = gameManager.neutralCount / neutralEffect;
                neutralValue = (int)(gameManager.neutralScore * neutralMulti);
            }
            gameManager.UpdateScore(neutralValue);
            gameManager.neutralScore = 0;
            gameManager.neutralCount = 0;
    }

}
