using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] int scorePoints = 5;

    public int ScorePoints { get { return scorePoints; } set { scorePoints = value;  } }
}
