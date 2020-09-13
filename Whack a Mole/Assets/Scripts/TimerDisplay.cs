using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    //TODO move levelLength functionality into another TimeManager or LevelManager class
    [SerializeField] private int levelLengthInSeconds = 0;
    private Slider _slider;
    
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();                                       // Get reference to Slider Component
        StartSlider(levelLengthInSeconds);                                                 // Start the slider display
    }
    
    private void StartSlider(int levelSeconds)
    {
        _slider.maxValue = levelSeconds;
        InvokeRepeating(nameof(TimerDisplay.UpdateDisplay), 1f, 1f);        // Start incrementing the slider
    }
    
    private void UpdateDisplay()
    {
        _slider.value ++;
        if (Mathf.Approximately(_slider.value, levelLengthInSeconds))                // Stop incrementing counter once time is up
        {
            CancelInvoke();                                                               
        }
    }
}
