using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private int levelTimeInSeconds = 0;
    
    private int _secondsSinceStart = 0;
    private LevelTimerUI _levelTimerUI = null;

    private void Start()
    {
        _levelTimerUI = GameObject.FindGameObjectWithTag("LevelTimerUI").GetComponent<LevelTimerUI>();                    // Get a reference to and set up the LevelTimerUI
        _levelTimerUI.Setup(levelTimeInSeconds);

        //TODO start the timer for now, later move this responsibility into a LevelManager class
        StartTimer();
    }
    
    private void StartTimer()
    {
        InvokeRepeating(nameof(LevelTimer.UpdateTimer), 1f, 1f);                                          // Start updating the timer
    }

    private void StopTimer()
    {
        CancelInvoke();
    }
    
    private void UpdateTimer()
    {
        _secondsSinceStart ++;                                                                                           // Update the display every second
        _levelTimerUI.UpdateDisplay(_secondsSinceStart);

        if (_secondsSinceStart == levelTimeInSeconds)                                                                    // Level has run out of time, stop timer
        {
            StopTimer();
        }
    }
}
