using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void PlayAgainTapped() 
    {
        SceneManager.LoadScene(0);
    }

    public void QuitTapped() 
    {
        Application.Quit();
    }

    public void NinjaShopTapped() 
    {
        SceneManager.LoadScene(2);
    }
}
