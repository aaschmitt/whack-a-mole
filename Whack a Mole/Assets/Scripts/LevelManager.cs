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
    
    [SerializeField] private GameObject screenPreGameplay = null;
    [SerializeField] private GameObject screenGamePlay = null;
    [SerializeField] private GameObject screenEnd = null;
    [SerializeField] private GameObject gameplayCursor = null;

    private LevelTimer _levelTimer = null;
    private LevelScore _levelScore = null;

    private void Start()
    {
        // Set pre-gameplay screen, disable others
        screenPreGameplay.SetActive(true);
        screenGamePlay.SetActive(false);
        screenEnd.SetActive(false);
        
        // Disable gameplay cursor
        gameplayCursor.SetActive(false);
    }

    /*
     * Desc: Starts the level -- Starts level timer and starts spawning gophers
     */
    public void StartLevel()
    {
        // Set gameplay screen, disable pre-gameplay screen
        screenPreGameplay.SetActive(false);
        screenEnd.SetActive(false);
        screenGamePlay.SetActive(true);
        
        // Activate gameplay cursor
        gameplayCursor.SetActive(true);
        
        // WAS PREVIOUSLY IN START()
        InstantiateLevelObjects();
        LoadLevelSettings();
        LevelTimer.TimerFinished += EndLevel;
        
        _levelTimer.StartTimer();
        StartSpawningGophers();
    }

    /*
     * Desc: Stops the level -- Stops the timer and stops spawning gophers, also destroys any that were left in the scene
     */
    private void EndLevel()
    {
        // Set end level screen, disable gameplay screen
        //screenGamePlay.SetActive(false);
        screenEnd.SetActive(true);
        
        // Disable gameplay cursor
        gameplayCursor.SetActive(false);
        
        _levelTimer.StopTimer();
        StopSpawningGophers();
    }
    
    /*
     * Desc: Loads the level settings defined in the LevelSettings ScriptableObject (see levelSettings instance variable)
     */
    private void LoadLevelSettings()
    {
        _levelTimer.LevelTimeInSeconds = levelSettings.levelLengthInSeconds;

        //TODO use LINQ?
        foreach (var gopherSpawner in gopherSpawners)
        {
            var component = gopherSpawner.GetComponent<GopherSpawner>();
            component.MinTimeToNextSpawn = levelSettings.minSecondsToSpawn;
            component.MaxTimeToNextSpawn = levelSettings.maxSecondsToSpawn;
            component.MinGopherLifetime = levelSettings.minGopherLifetime;
            component.MaxGopherLifetime = levelSettings.maxGopherLifetime;
        }
    }
    
    /*
     * Desc: Instantiates instances of necessary level objects -- LevelScore and LevelTimer
     */
    private void InstantiateLevelObjects()
    {
        _levelScore = Instantiate(levelScorePrefab, this.transform).GetComponent<LevelScore>();
        _levelTimer = Instantiate(levelTimerPrefab, this.transform).GetComponent<LevelTimer>();
    }

    #region Gopher Spawning
    /*
     * Desc: Iterates through all of the GopherSpawners and activates them -- starts spawning gophers
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
     * Desc: Iterates through all of the GopherSpawners and deactivates them -- stops spawning gophers
     */
    private void StopSpawningGophers()
    {
        foreach (var gopherSpawner in gopherSpawners)
        {
            var component = gopherSpawner.GetComponent<GopherSpawner>();
            component.StopSpawning();
        }
    }
    #endregion

    private void OnDestroy()
    {
        LevelTimer.TimerFinished -= EndLevel;                                                // Unsubscribe to TimerFinished event on destruction of this object
    }
}
