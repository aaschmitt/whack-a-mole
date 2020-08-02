using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    // instance variables
    public int levelTimeInSeconds;

    private const int EasyLevelLength = 120;
    private const int MediumLevelLength = 80;
    private const int HardLevelLength = 45;

    private TimerDisplay _timerDisplay;

    // The LevelManager class is the overarching class that encapsulates the entirety of the level. Takes user input / gameplay and communicates with the UI
    public delegate void GopherClick(int score);
    public static event GopherClick onGopherClick;

    // Define difficulty enum
    public enum LevelDifficulty {

        Easy,           // gophers live longer, more chance for higher-value gophers to spawn (120 seconds)
        Medium,         // gophers live average length, average chance for higher-value gophers to spawn (80 seconds)
        Hard            // gophers live short, small chance for higher-value gophers to spawn (45 seconds)

    }

    public LevelDifficulty levelDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        // Grab reference to the TimerDisplay
        _timerDisplay = (TimerDisplay) FindObjectOfType(typeof(TimerDisplay));

        // Configure level settings based upon difficulty selected
        ConfigureLevelSettings(levelDifficulty);

        // Start the timer
        if (_timerDisplay) {
            _timerDisplay.StartTimer(levelTimeInSeconds);
            Debug.Log("Timer started");
        }
        else {
            Debug.Log("No TimerDisplay found.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnnounceGopherDeath(int scoreToAdd) {

        Debug.Log("A gopher has been clicked!");

        if (onGopherClick != null) {

            onGopherClick(scoreToAdd);

        }

    }

    public void EndLevel() {

        Debug.Log("Time is up!");
        
        //TODO: Display end screen

    }

    private void ConfigureLevelSettings(LevelDifficulty difficulty) {

        switch (difficulty)
        {

            case LevelDifficulty.Easy:

                Debug.Log("Level set to Easy");
                levelTimeInSeconds = EasyLevelLength;

                break;

            case LevelDifficulty.Medium:

                Debug.Log("Level set to Medium");
                levelTimeInSeconds = MediumLevelLength;

                break;

            case LevelDifficulty.Hard:

                Debug.Log("Level set to Hard");
                levelTimeInSeconds = HardLevelLength;

                break;
        }

    }


}
