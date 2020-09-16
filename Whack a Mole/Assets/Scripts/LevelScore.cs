﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    [SerializeField] private int scorePerGopher = 0;
    private int _currentScore = 0;

    private LevelScoreUI _levelScoreUI = null;
    
    // Start is called before the first frame update
    void Start()
    {
        _levelScoreUI = GameObject.FindGameObjectWithTag("LevelScoreUI").GetComponent<LevelScoreUI>();            // Get reference to LevelScoreUI and set it up
        _levelScoreUI.Setup();
        GopherSpawner.GopherClicked += AddScore;                                                                  // Subscribe to the GopherClicked event
    }

    private void AddScore()
    {
        _currentScore += scorePerGopher;                                                                         // Add score and update display
        _levelScoreUI.UpdateDisplay(_currentScore);
    }
}
