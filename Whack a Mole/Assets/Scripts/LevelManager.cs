using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //TODO have the LevelManager create its own instances of the LevelScore and LevelTimer -- eliminates need to in editor whenever making a new level
    [SerializeField] private GameObject levelScoreGameObject = null;
    [SerializeField] private GameObject levelTimerGameObject = null;
    [SerializeField] private LevelSettings levelSettings = null;

    private LevelTimer _levelTimer = null;
    private LevelScore _levelScore = null;
    
    private void Start()
    {
        _levelScore = levelScoreGameObject.GetComponent<LevelScore>();                                    // Get references to the levelScore and levelTimer
        _levelTimer = levelTimerGameObject.GetComponent<LevelTimer>();

        LoadLevelSettings();
        StartLevel();
    }

    private void StartLevel()
    {
        _levelTimer.StartTimer();
        //TODO start spawning gophers
    }

    private void EndLevel()
    {
        _levelTimer.StopTimer();
        //TODO stop spawning gophers -- destroy any that were already spawned
    }
    
    private void LoadLevelSettings()
    {
        _levelTimer.LevelTimeInSeconds = levelSettings.levelLengthInSeconds;
        _levelScore.ScorePerGopher = levelSettings.scorePerGopher;
    }
}
