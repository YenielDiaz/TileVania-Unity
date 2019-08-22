﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        //make sure object persists
        int gameSeshCount = FindObjectsOfType<GameSession>().Length;
        if(gameSeshCount > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }

    void Start()
    {
        
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1) { TakeLives(); }
        else { ResetGameSession(); }
    }

    private void TakeLives()
    {
        playerLives--;
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIndex);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene("Main Menu");
        Destroy(gameObject);
    }
}
