using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float playerScore = 0;

    public float PlayerScore 
    { 
        get { return playerScore; } 
        set { playerScore = value; } 
    }
}
