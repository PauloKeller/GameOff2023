using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class StartGame : MonoBehaviour
{
    
    GameSession gameSession;
    private void Start()
    {   
        gameSession = FindObjectOfType<GameSession>();
    }
    
    public void PlayGame() 
    {
        SceneManager.LoadScene(2);
    }

    public void QuitTapped() 
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
