﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}