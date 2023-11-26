using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;

    Rigidbody2D bulletRigidbody2D;
    PlayerMoviment playerMoviment;
    GameSession gameSession;
    float xSpeed = 0f;

    void Start()
    {
        bulletRigidbody2D = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, 90);
        playerMoviment = FindObjectOfType<PlayerMoviment>();
        gameSession = FindObjectOfType<GameSession>();
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
            gameSession.Score += enemy.ScorePoints;

            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
