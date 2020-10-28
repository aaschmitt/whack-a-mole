using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GopherSpawner : MonoBehaviour
{
    public static event UnityAction<int> GopherClicked;

    public float MinTimeToNextSpawn { get; set; }
    public float MaxTimeToNextSpawn { get; set; }
    public float MinGopherLifetime { get; set; }
    public float MaxGopherLifetime { get; set; }

    [SerializeField] private Gopher[] gopherPrefabs = null;
    [SerializeField] private Transform spawnPoint = null;
    [SerializeField] private ParticleSystem spawnParticleEffect = null;
    [SerializeField] private float bombSpawnPercentage = 0f;

    private bool _isActive = false;
    private bool _hasGopher = false;
    private Gopher _currentGopher = null;
    private Coroutine _gopherSpawning = null;

    /*
     * A gopher is spawned at sometime between MinTimeToNextSpawn and MaxTimeToNextSpawn (defined in LevelOneData SO)
     * If the spawner is not occupied (!_hasGopher), spawn a gopher. 
     */
    private IEnumerator WaitAndSpawn()
    {
        while (true)                                                                                         // Continue spawning gophers until explicitly told not to
        {
            if (!_currentGopher) _hasGopher = false;                                                         // If _currentGopher is null (doesn't exist), spawner does not have a gopher
            yield return new WaitForSeconds(Random.Range(MinTimeToNextSpawn, MaxTimeToNextSpawn));           // Wait for a randomly generated amount of time (1 - 4 seconds)
            if (_isActive) SpawnGopher();
        }
    }
    
    /*
     * Deactivates the spawner for a period of time
     */
    private IEnumerator DisableSpawner()
    {
        _isActive = false;
        yield return new WaitForSeconds(_currentGopher.disableSpawnerTime);
        _isActive = true;
    }
    
    /*
     * Method to spawn a gopher
     * Instantiates spawn particle effect, Instantiates a new Gopher, gives it a random lifetime from defined values in LevelOneData SO
     */
    private void SpawnGopher()
    {
        if (_hasGopher) return;
        int index = ChooseGopher();                                                        // Select a random gopher to spawn based on passed values in inspector
        Instantiate(spawnParticleEffect, spawnPoint);                                     // Instantiate a spawn particle effect
        _currentGopher = Instantiate(gopherPrefabs[index], spawnPoint);                   // Instantiate a Gopher gameObject at the same location as this spawner
        _currentGopher.Lifetime = Random.Range(MinGopherLifetime, MaxGopherLifetime);
        _hasGopher = true;                                                                // After Instantiating a gopher, the spawner now has an active gopher
    }
    
    /*
     * Method to "whack" a mole and gift the player points
     * If the spawner has a gopher (_hasGopher), destroy the gopher and send the message that a gopher was clicked and destroyed
     */
    private void OnMouseDown()
    {
        if (!_hasGopher) return;                                             // If there is an active gopher, destroy it and {print a message}
        GopherClicked?.Invoke(_currentGopher.score);                         // Send the message that a gopher was clicked
        if (_currentGopher)
        {
            _currentGopher.SpawnClickEffect();
            Destroy(_currentGopher.gameObject);
        }
        _hasGopher = false;
        StartCoroutine(DisableSpawner());
    }

    /*
     * Method to start the WaitAndSpawn coroutine. Called from LevelManager
     */
    public void StartSpawning()
    {
        _isActive = true;
        _gopherSpawning = StartCoroutine(WaitAndSpawn());
    }

    /*
     * Method to stop the WaitAndSpawn coroutine. If the spawner has a gopher (_hasGopher), destroy it
     */
    public void StopSpawning()
    {
        if (_hasGopher && _currentGopher != null) Destroy(_currentGopher.gameObject);                   // If there is an active gopher, destroy it
        StopCoroutine(_gopherSpawning);                                                                 // Stop the spawning gophers with coroutine
    }

    private int ChooseGopher()
    {
        float randNum = Random.Range(0.0f, 1.0f);
        if (randNum < bombSpawnPercentage)
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }
}
