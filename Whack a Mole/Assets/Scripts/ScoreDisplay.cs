using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    //TODO move score functionality out of ScoreDisplay into a LevelManager class
    [SerializeField] private int scoreToAdd = 5;
    private int _currentScore = 0;
    
    private TextMeshProUGUI _textMeshPro;
    
    void Start()
    {
        _textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();               // Get reference to TextMeshProUGUI component & set to starting text
        UpdateDisplay();
        
        GopherSpawner.GopherClicked += AddScore;                                 // Subscribe to GopherClicked event with AddScore
    }

    private void AddScore()
    {
        _currentScore += scoreToAdd;
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        _textMeshPro.text = "Score: " + _currentScore;
    }
}
