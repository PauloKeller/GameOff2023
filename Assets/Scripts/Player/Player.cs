using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] PowerUps[] playerPowerUps = new PowerUps[] { };
    CapsuleCollider2D playerCapsuleCollider2D;
    float playerScore = 0f;
    bool isAlive = true;

    public float PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    public PowerUps[] PlayerPowerUps 
    {
        get { return playerPowerUps; }
        set { playerPowerUps = value; }
    }

    private void Start()
    {
        playerCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        CheckTouchingLayer();
    }

    void CheckTouchingLayer()
    {
        if (playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies"))) Die();
    }

    public void Die()
    {
        isAlive = false;
        StartCoroutine(LoadGameSceneCoroutine(1.0f));
    }

    // TODO: Move this to player or scene manager
    IEnumerator LoadGameSceneCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
        Destroy(gameObject);
    }
}
