using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{

    int coins = 0;

    public int Coins 
    {
        get { return coins; }
        set { 
            coins = value;
            Debug.Log("Coins: " + coins);
        }
    }
}
