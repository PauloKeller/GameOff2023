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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
