using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    Player player;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        scoreText.text = player.PlayerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.PlayerScore.ToString();
    }
}
