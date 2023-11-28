using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingEnemy : Enemy
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float fireRate = 2;

    bool canFireAgain = true;

    void Update()
    {
        if (canFireAgain) StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine() 
    {
        canFireAgain = false;
        yield return new WaitForSeconds(fireRate);
        canFireAgain = true;
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
