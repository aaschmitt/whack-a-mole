using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // The LevelManager class is the overarching class that encapsulates the entirety of the level. Takes user input / gameplay and communicates with the UI
    public delegate void GopherClick(int score);
    public static event GopherClick onGopherClick;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
