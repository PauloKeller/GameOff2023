using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingEnemy : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float fireRate = 2;

    bool canFireAgain = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
