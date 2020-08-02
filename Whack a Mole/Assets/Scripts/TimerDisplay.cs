using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    TextMeshProUGUI timerText;
    int timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        // Grab reference to the TMPro component
        timerText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to start the timer
    public void StartTimer(int timeInSeconds) {

        // Set the timeRemaining variable
        timeRemaining = timeInSeconds;

        // Update the display every second
        InvokeRepeating("UpdateDisplay", 0f, 1.0f);        

    }

    void UpdateDisplay() {

        timerText.text = timeRemaining.ToString();
        timeRemaining--;

        if (timeRemaining < 0) {

            Debug.Log("Timer Display has run to zero");
            CancelInvoke("UpdateDisplay");

        }

    }
}
