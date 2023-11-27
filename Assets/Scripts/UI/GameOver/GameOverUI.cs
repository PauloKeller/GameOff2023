using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI newScoreText;

    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        
        newScoreText.text = GetNewScoreText();
        highScoreText.text = GetHighScoreText();

        SavHighScore();
    }

    void SavHighScore() 
    {
        if (gameSession.Score > gameSession.LoadHighScore())
        {
            gameSession.SaveLastScore();
        }
    }

    void ResetScore()
    {
        gameSession.Score = 0;
    }

    string GetNewScoreText() 
    {
        string scoreText = gameSession.Score.ToString();
        return $"Your new score: {scoreText}";
    }

    string GetHighScoreText()
    {
        string scoreText = gameSession.LoadHighScore().ToString();
        return $"Your higher score was: {scoreText}";
    }

    public void PlayAgainTapped() 
    {
        ResetScore();
        SceneManager.LoadScene(2);
    }

    public void QuitTapped() 
    {
        Application.Quit();
    }

    public void NinjaShopTapped()
    {
        ResetScore();
        SceneManager.LoadScene(3);
    }
}
