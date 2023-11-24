using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;

    Rigidbody2D bulletRigidbody2D;
    PlayerMoviment playerMoviment;
    Player player;
    float xSpeed = 0f;

    void Start()
    {
        bulletRigidbody2D = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 90);
        playerMoviment = FindObjectOfType<PlayerMoviment>();
        player = FindObjectOfType<Player>();
        xSpeed = playerMoviment.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        bulletRigidbody2D.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") 
        {
            var enemy = other.GetComponent<Enemy>();
            player.PlayerScore += enemy.ScorePoints;
            Debug.Log($"Player Score: {player.PlayerScore}");
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
