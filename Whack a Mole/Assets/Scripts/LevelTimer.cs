using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public int LevelTimeInSeconds { get; set; }

    private int _secondsSinceStart = 0;
    private LevelTimerUI _levelTimerUI = null;

    private void Start()
    {
        _levelTimerUI = GameObject.FindGameObjectWithTag("LevelTimerUI").GetComponent<LevelTimerUI>();                   // Get a reference to and set up the LevelTimerUI
        _levelTimerUI.Setup(LevelTimeInSeconds);
    }
    
    public void StartTimer()
    {
        InvokeRepeating(nameof(LevelTimer.UpdateTimer), 1f, 1f);                                          // Start updating the timer
    }

    public void StopTimer()
    {
        CancelInvoke();
    }
    
    private void UpdateTimer()
    {
        _secondsSinceStart ++;                                                                                           // Update the display every second
        _levelTimerUI.UpdateDisplay(_secondsSinceStart);

        if (_secondsSinceStart == LevelTimeInSeconds)                                                                    // Level has run out of time, stop timer
        {
            StopTimer();
        }
    }
}
