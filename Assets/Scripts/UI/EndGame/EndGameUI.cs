using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    void ResetGameData() {
        PlayerPrefs.DeleteAll();
    }

    public void StartNewGameTapped()
    {
        ResetGameData();
        SceneManager.LoadScene(2);
    }

    public void QuitTapped()
    {
        Application.Quit();
    }
}
