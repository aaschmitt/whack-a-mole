using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    public void UpdateDisplay(int score)
    {
        _textMeshPro.text = "Score: " + score;
    }

    public void Setup()
    {
        _textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();            // Get reference to TextMeshProUGUI component & set to starting text
        UpdateDisplay(0);
    }
}
