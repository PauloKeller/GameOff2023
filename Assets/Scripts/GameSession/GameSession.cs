using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum PlayerPrefsKeys 
{
    Coins,
    PowerUps
}

public class GameSession : MonoBehaviour
{
    [SerializeField] int coins = 0;
    [SerializeField] PowerUps[] playerPowerUps = new PowerUps[] { };

    public int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
            SaveCoins();
            Debug.Log("Coins: " + coins);
        }
    }

    public PowerUps[] PlayerPowerUps
    {
        get { return playerPowerUps; }
        set { playerPowerUps = value; }
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
        //PlayerPrefs.SetInt(nameof(PlayerPrefsKeys.PowerUps), -1);
        playerPowerUps = LoadPlayerPowerUps();
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
        Debug.Log($"Saved power ups: {playerPowerUps.Length - 1}");
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
            Debug.Log($"Power up loaded: {powerUp}");
        } 
        return playerPowerUps.ToArray();
    }
}
