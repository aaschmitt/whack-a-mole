using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    public int ScorePerGopher { get; set; }
    
    private int _currentScore = 0;
    private LevelScoreUI _levelScoreUI = null;
    
    private void Start()
    {
        ConfigureUI();
        GopherSpawner.GopherClicked += AddScore;                                                                  // Subscribe to the GopherClicked event
    }

    private void ConfigureUI()
    {
        _levelScoreUI = GameObject.FindGameObjectWithTag("LevelScoreUI").GetComponent<LevelScoreUI>();            // Get reference to LevelScoreUI and set it up
        _levelScoreUI.Setup();
    }

    private void AddScore()
    {
        _currentScore += ScorePerGopher;                                                                         // Add score and update display
        _levelScoreUI.UpdateDisplay(_currentScore);
    }

    private void OnDestroy()
    {
        GopherSpawner.GopherClicked -= AddScore;                                                                // Unsubscribe to GopherClicked event on destruction of this object
    }
}
