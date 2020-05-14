using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadGameOver()
    {
        Debug.Log("LoadGameOver");
        SceneManager.LoadScene(2);
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
