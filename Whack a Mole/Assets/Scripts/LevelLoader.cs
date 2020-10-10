using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu = null;
    [SerializeField] private GameObject mainMenu = null;
    public void LoadPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void LoadMain()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
