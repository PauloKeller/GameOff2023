using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temple : MonoBehaviour
{
    bool isGameEnd = false;
    GameSession gameSession;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isGameEnd) 
        {
            isGameEnd = true;
            StartCoroutine(LoadGameSceneCoroutine());
        }
    }

    IEnumerator LoadGameSceneCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameSession.gameObject);
        SceneManager.LoadScene(4);
    }
}
