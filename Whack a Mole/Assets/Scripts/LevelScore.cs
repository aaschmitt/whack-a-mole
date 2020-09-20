using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    private int _currentScore = 0;
    public int ScorePerGopher { get; set; }

    private LevelScoreUI _levelScoreUI = null;
    
    void Start()
    {
        _levelScoreUI = GameObject.FindGameObjectWithTag("LevelScoreUI").GetComponent<LevelScoreUI>();            // Get reference to LevelScoreUI and set it up
        _levelScoreUI.Setup();
        GopherSpawner.GopherClicked += AddScore;                                                                  // Subscribe to the GopherClicked event
    }

    private void AddScore()
    {
        _currentScore += ScorePerGopher;                                                                         // Add score and update display
        _levelScoreUI.UpdateDisplay(_currentScore);
    }
}
