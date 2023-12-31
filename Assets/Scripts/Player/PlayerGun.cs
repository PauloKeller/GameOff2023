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

    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnFire(InputValue value)
    {
        FireWeapon();
    }

    void FireWeapon() {
        if (gameSession.PowerUps.Contains(PowerUps.NinjaKunai))
        {
            Instantiate(bullet, gun.position, transform.rotation);
        }
    }
}
