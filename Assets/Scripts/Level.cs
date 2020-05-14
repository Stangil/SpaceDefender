using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayLoadGamerOver = 3.0f;
    public void LoadGameOver()
    {
        Debug.Log("Before Coroutine");
        StartCoroutine(DelayLoadGameOver());
    }

   private IEnumerator DelayLoadGameOver()
    {
        yield return new WaitForSeconds(delayLoadGamerOver);
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
