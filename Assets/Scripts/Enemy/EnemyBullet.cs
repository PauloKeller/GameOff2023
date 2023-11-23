using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 2f;
    Rigidbody2D bulletRigidBody2D;
    Player player;
    void Start()
    {
        bulletRigidBody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        bulletRigidBody2D.velocity = new Vector2(bulletSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hit player");
            player.Die();
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
