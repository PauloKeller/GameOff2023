using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingEnemy : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float fireRate = 2;
    Enemy enemy;

    bool canFireAgain = true;

    void Start()
    { 
        enemy = GetComponentInParent<Enemy>();
    }

    void Update()
    {
        if (canFireAgain) StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine() 
    {
        canFireAgain = false;
        yield return new WaitForSeconds(fireRate);
        canFireAgain = true;

        var obj = Instantiate(bullet, gun.position, transform.rotation);
        obj.GetComponent<EnemyBullet>().SetBulletHorizontalAxis(enemy.transform.localScale.x);
    }    
    
}
