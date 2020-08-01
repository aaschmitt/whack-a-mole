using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] int score = 0;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start() {

        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();

        // Subscribe to the onGopherClick event
        LevelManager.onGopherClick += AddScore;

    }

    private void UpdateDisplay() {

        scoreText.text = score.ToString();

    }

    
    public void AddScore(int amount) {

        score += amount;
        UpdateDisplay();

    }
    
    /*
    public void AddScore() {
        score += 10;
        UpdateDisplay();
    }
    */
}
