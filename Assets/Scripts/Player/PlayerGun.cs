using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    void OnFire(InputValue value) 
    {
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
