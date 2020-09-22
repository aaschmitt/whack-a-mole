using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelTimer : MonoBehaviour
{
    public static event UnityAction TimerFinished;
    public int LevelTimeInSeconds { get; set; }

    private int _secondsSinceStart = 0;
    private LevelTimerUI _levelTimerUI = null;

    private void Start()
    {
        ConfigureUI();
    }

    /*
     * Desc: Configures the LevelTimerUI instance
     * Gets a reference to the LevelTimerUI in the scene and calls it's Setup() method
     */
    private void ConfigureUI()
    {
        _levelTimerUI = GameObject.FindGameObjectWithTag("LevelTimerUI").GetComponent<LevelTimerUI>();                   // Get a reference to and set up the LevelTimerUI
        _levelTimerUI.Setup(LevelTimeInSeconds);
    }
    
    /*
     * Desc: Starts the LevelTimer
     * Starts the timer by using InvokeRepeating(), calling UpdateTimer() every second
     */
    public void StartTimer()
    {
        InvokeRepeating(nameof(LevelTimer.UpdateTimer), 1f, 1f);                                          // Start updating the timer
    }

    /*
     * Desc: Stops the timer
     * Stops the timer by cancelling the invoke method called in StartTimer()
     */
    public void StopTimer()
    {
        CancelInvoke();
    }
    
    /*
     * Desc: Updates the timer
     * Keeps track of how many seconds have passed
     * Updates the LevelTimerUI display by calling its UpdateDisplay() method
     * Triggers the TimerFinished event if the timer has run out of time -- Stops the timer
     */
    private void UpdateTimer()
    {
        _secondsSinceStart ++;                                                                                           // Update the display every second
        _levelTimerUI.UpdateDisplay(_secondsSinceStart);
        if (_secondsSinceStart != LevelTimeInSeconds) return;
        TimerFinished?.Invoke();
        StopTimer();
    }
}
