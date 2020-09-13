using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GopherSpawner : MonoBehaviour
{
    public static event UnityAction GopherClicked;
    
    [SerializeField] private GameObject gopherPrefab = null;

    private bool _hasGopher = false;
    private GameObject _currentGopher = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndSpawn());                               // Start spawning gophers           
    }

    private IEnumerator WaitAndSpawn()
    {
        while (true)                                                         // Continue spawning gophers until explicitly told not to
        {
            yield return new WaitForSeconds(Random.Range(1f, 4f));           // Wait for a randomly generated amount of time (1 - 4 seconds)
            if (!_hasGopher)                                                 // If spawner has no gopher, spawn one. Else, wait another round
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
        _currentGopher = Instantiate(gopherPrefab, this.transform);          // Instantiate a Gopher gameObject at the same location as this spawner
    }

    private void OnMouseDown()
    {
        if (!_hasGopher) return;                                             // If there is an active gopher, destroy it and {print a message}
        Destroy(_currentGopher);
        _hasGopher = false;
        GopherClicked?.Invoke();                                             // Send the message that a gopher was clicked
    }
}
