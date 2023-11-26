using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI scoreText;

    GameSession gameSession;
   
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        scoreText.text = gameSession.Score.ToString();
    }
}
