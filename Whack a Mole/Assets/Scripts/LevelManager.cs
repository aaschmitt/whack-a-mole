using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelScorePrefab = null;
    [SerializeField] private GameObject levelTimerPrefab = null;
    [SerializeField] private LevelSettings levelSettings = null;
    [SerializeField] private List<GameObject> gopherSpawners = null;

    private LevelTimer _levelTimer = null;
    private LevelScore _levelScore = null;

    private void Start()
    {
        InstantiateLevelObjects();
        LoadLevelSettings();
        StartLevel();
    }

    /*
     * Starts the level -- Starts level timer and starts spawning gophers
     */
    private void StartLevel()
    {
        _levelTimer.StartTimer();
        StartSpawningGophers();
    }

    /*
     * Stops the level -- Stops the timer and stops spawning gophers, also destroys any that were left in the scene
     */
    private void EndLevel()
    {
        _levelTimer.StopTimer();
        StopSpawningGophers();
    }
    
    /*
     * Loads the level settings defined in the LevelSettings ScriptableObject (see levelSettings instance variable)
     */
    private void LoadLevelSettings()
    {
        _levelTimer.LevelTimeInSeconds = levelSettings.levelLengthInSeconds;
        _levelScore.ScorePerGopher = levelSettings.scorePerGopher;
    }
    
    /*
     *  Instantiates instances of necessary level objects -- LevelScore and LevelTimer
     */
    private void InstantiateLevelObjects()
    {
        _levelScore = Instantiate(levelScorePrefab, this.transform).GetComponent<LevelScore>();
        _levelTimer = Instantiate(levelTimerPrefab, this.transform).GetComponent<LevelTimer>();
    }

    #region Gopher Spawning
    /*
     * Iterates through all of the GopherSpawners and activates them -- starts spawning gophers
     */
    private void StartSpawningGophers()
    {
        //TODO use LINQ?
        foreach (var gopherSpawner in gopherSpawners)
        {
            var component = gopherSpawner.GetComponent<GopherSpawner>();
            component.StartSpawning();
        }
    }

    /*
     * Iterates through all of the GopherSpawners and deactivates them -- stops spawning gophers
     */
    private void StopSpawningGophers()
    {
        //TODO use LINQ?
        foreach (var gopherSpawner in gopherSpawners)
        {
            var component = gopherSpawner.GetComponent<GopherSpawner>();
            component.StopSpawning();
        }
    }
    #endregion
}
