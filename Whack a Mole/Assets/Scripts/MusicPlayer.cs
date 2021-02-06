using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        var musicPlayers = FindObjectsOfType<MusicPlayer>();
        if (musicPlayers.Length > 1)
        {
            Destroy(musicPlayers[1].gameObject);
        }
        
        DontDestroyOnLoad(this);
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
    }
    public void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
    }
}
