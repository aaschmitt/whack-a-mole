using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevelOne()
    {

        // Load level one
        SceneManager.LoadScene("LevelOne");

    }

    public void LoadOptionsLevel()
    {

        // Load the options menu
        // SceneManager.LoadScene("Options");

    }

    public void QuitGame()
    {

        // Quit game and exit window

    }
}
