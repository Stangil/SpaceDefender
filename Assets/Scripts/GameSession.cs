using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    int score = 0;
    int playerHealth;
    private void Awake()
    {
        SetUpSingleTon();
    }
    private void Start()
    {
        playerHealth = FindObjectOfType<Player>().GetPlayerHealth();
    }
    private void SetUpSingleTon()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public int GetPlayerHealth()
    {
        if (playerHealth > 0) 
        {
            return playerHealth;
        }
        else
        {
            return 0;
        }
    }
    public void SetHealth(int health)
    {
        playerHealth = health;
    }
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
