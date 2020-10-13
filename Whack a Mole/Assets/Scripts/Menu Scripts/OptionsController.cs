using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 0.5f;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    /*
     * Saves the changes made in Options to the PlayerPrefs using PlayerPrefsController
     */
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);        // Save volume value
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }

    /*
     * Gets called on volumeSlider's 'value changed' event
     * Finds and adjusts the volume on the MusicPlayer component in the scene
     */
    public void SetVolume()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        musicPlayer.GetComponent<MusicPlayer>();
        musicPlayer.SetVolume(volumeSlider.value);
    }
}
