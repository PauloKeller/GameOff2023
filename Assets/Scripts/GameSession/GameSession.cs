using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum PlayerPrefsKeys 
{
    Coins,
    PowerUps,
    Score
}

public class GameSession : MonoBehaviour
{
    [SerializeField] int coins = 0;
    [SerializeField] PowerUps[] powerUps = new PowerUps[] { };
    [SerializeField] int score = 0;

    public int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
            SaveCoins();
        }
    }

    public PowerUps[] PowerUps
    {
        get { return powerUps; }
        set { powerUps = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        LoadGameSessionData();
    }

    void LoadGameSessionData()
    {
        powerUps = LoadPlayerPowerUps();
        coins = LoadCoins();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt(nameof(PlayerPrefsKeys.Coins), coins);
    }

    public int LoadCoins() 
    {
        return PlayerPrefs.GetInt(nameof(PlayerPrefsKeys.Coins), 0);
    }

    public void SavePlayerPowerUps(PowerUps[] playerPowerUps) 
    {
        PlayerPrefs.SetInt(nameof(PlayerPrefsKeys.PowerUps), playerPowerUps.Length - 1);
    }

    public PowerUps[] LoadPlayerPowerUps() 
    {
        List<PowerUps> playerPowerUps = new List<PowerUps> { };
        int numOfPowerUps = PlayerPrefs.GetInt(nameof(PlayerPrefsKeys.PowerUps), -1);

        for (int index = 0; index <= numOfPowerUps; index++) 
        {
            PowerUps powerUp = (PowerUps)Enum.ToObject(typeof(PowerUps), index);
            playerPowerUps.Add(powerUp);
        } 
        return playerPowerUps.ToArray();
    }

    public void SaveLastScore()
    {
        PlayerPrefs.SetInt(nameof(PlayerPrefsKeys.Score), score);
    }

    public int LoadHighScore() 
    {
        return PlayerPrefs.GetInt(nameof(PlayerPrefsKeys.Score), 0);
    }
}
