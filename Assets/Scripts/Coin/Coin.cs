using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int points = 1;

    bool wasCollected = false;
    PlayerWallet playerWallet;

    void Start()
    {
        playerWallet = FindObjectOfType<PlayerWallet>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected) 
        {
            playerWallet.Coins += points;
            wasCollected = true;
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
