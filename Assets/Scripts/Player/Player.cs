using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    CapsuleCollider2D playerCapsuleCollider2D;
    float playerScore = 0f;
    bool isAlive = true;
    GameSession gameSession;

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
        StartCoroutine(LoadGameSceneCoroutine());
    }
    // TODO: Move this to player or scene manager
    IEnumerator LoadGameSceneCoroutine()
    {
        SceneManager.LoadScene(1);
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
