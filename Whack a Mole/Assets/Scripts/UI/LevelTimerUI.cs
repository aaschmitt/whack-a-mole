using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimerUI : MonoBehaviour
{
    private Slider _slider;

    public void UpdateDisplay(int value)
    {
        _slider.value = value;
    }

    public void Setup(int levelLengthInSeconds)
    {
        _slider = gameObject.GetComponent<Slider>();
        _slider.maxValue = levelLengthInSeconds;
    }
}
