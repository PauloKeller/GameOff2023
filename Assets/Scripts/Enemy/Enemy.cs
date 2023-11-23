using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePoints = 5;

    public int ScorePoints { get { return scorePoints;  } }
}
