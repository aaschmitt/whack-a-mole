using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
    }
    public void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
    }
}
