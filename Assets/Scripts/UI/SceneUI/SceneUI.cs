using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Image kunaiImage;

    GameSession gameSession;
   
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.LoadPlayerPowerUps();
        gameSession.LoadCoins();

        if (IsKunaiAvailable()) 
        {
            var tempColor = kunaiImage.color;
            tempColor.a = 255f;
            kunaiImage.color = tempColor;
        }
    }

    void Update()
    {
        scoreText.text = gameSession.Score.ToString();
        coinsText.text = gameSession.Coins.ToString();
    }

    bool IsKunaiAvailable() 
    {
        return gameSession.PowerUps.Contains<PowerUps>(PowerUps.NinjaKunai);
    }
}
