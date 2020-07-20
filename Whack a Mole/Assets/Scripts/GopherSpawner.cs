using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GopherSpawner : MonoBehaviour
{
    // GopherSpawner handles spawning / despawning of Gophers

    public GameObject gopher;
    public GameObject gopherParent;
    private IEnumerator waitAndSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // Activate the GameObject -- start spawning gophers
        waitAndSpawn = WaitAndSpawn(3, 8);
        StartCoroutine(waitAndSpawn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Method to pick a random time between 'min' and 'max' seconds, calls 'SpawnGopher()' after selected number of seconds
    IEnumerator WaitAndSpawn(float min, float max) {

        while (true) {

            // Wait for selected time to finish
            yield return new WaitForSeconds(Random.Range(min,max));

            // Spawn a Gopher
            SpawnGopher();

        }

    }

    // Method to spawn a gopher - called from RandomTime
    void SpawnGopher() {

        Instantiate(gopher, new Vector3(transform.position.x, transform.position.y, transform.position.z - 3), transform.rotation, gopherParent.transform);
        Debug.Log("Gopher Spawned!");

    }
}
