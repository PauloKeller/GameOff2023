using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int points = 1;

    bool wasCollected = false;
    GameSession gameSession;
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected) 
        {
            gameSession.Coins += points;
            wasCollected = true;
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
