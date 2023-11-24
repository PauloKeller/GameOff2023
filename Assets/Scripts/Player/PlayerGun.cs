using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    void OnFire(InputValue value)
    {
        FireWeapon();
    }

    void FireWeapon() {
        if (player.PlayerPowerUps.Contains(PowerUps.NinjaKunai))
        {
            Instantiate(bullet, gun.position, transform.rotation);
        }
        else
        {
            Debug.Log("Does not have a weapon");
        }
    }
}
