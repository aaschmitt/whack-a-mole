using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class GopherSpawner : MonoBehaviour
{
    public static event UnityAction GopherClicked;

    public float MinTimeToNextSpawn { get; set; }
    public float MaxTimeToNextSpawn { get; set; }
    public float MinGopherLifetime { get; set; }
    public float MaxGopherLifetime { get; set; }

    [SerializeField] private Gopher gopherPrefab = null;
    [SerializeField] private Transform spawnPoint = null;
    [SerializeField] private ParticleSystem spawnParticleEffect = null;

    private bool _hasGopher = false;
    private Gopher _currentGopher = null;
    private Coroutine _gopherSpawning = null;

    
    private IEnumerator WaitAndSpawn()
    {
        while (true)                                                                                         // Continue spawning gophers until explicitly told not to
        {
            yield return new WaitForSeconds(Random.Range(MinTimeToNextSpawn, MaxTimeToNextSpawn));           // Wait for a randomly generated amount of time (1 - 4 seconds)
            if (!_hasGopher)                                                                                 // If spawner has no gopher, spawn one. Else, wait another round
            {
                SpawnGopher();
                _hasGopher = true;
            }
            else
            {
                _hasGopher = false;
            }
        }
    }

    private void SpawnGopher()
    {
        Instantiate(spawnParticleEffect, spawnPoint); // Instantiate a spawn particle effect
        if (_hasGopher) return;
        _currentGopher =
            Instantiate(gopherPrefab,
                spawnPoint); // Instantiate a Gopher gameObject at the same location as this spawner
        _currentGopher.Lifetime = Random.Range(MinGopherLifetime, MaxGopherLifetime);
    }

    private void OnMouseDown()
    {
        if (!_hasGopher) return;                                             // If there is an active gopher, destroy it and {print a message}
        if (_currentGopher) Destroy(_currentGopher.gameObject);
        _hasGopher = false;
        GopherClicked?.Invoke();                                             // Send the message that a gopher was clicked
    }

    public void StartSpawning()
    {
        _gopherSpawning = StartCoroutine(WaitAndSpawn());
    }

    public void StopSpawning()
    {
        if (_hasGopher && _currentGopher != null) Destroy(_currentGopher.gameObject);                   // If there is an active gopher, destroy it
        StopCoroutine(_gopherSpawning);                                                                 // Stop the spawning gophers with coroutine
    }
}
