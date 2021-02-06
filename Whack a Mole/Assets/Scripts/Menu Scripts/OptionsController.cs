using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Slider levelLengthSlider = null;
    
    [SerializeField] private float defaultVolume = 0.5f;
    [SerializeField] private float defaultLevelLength = 0.5f;

    [SerializeField] private TextMeshProUGUI levelLengthText = null;

    [SerializeField] private LevelSettings levelSettings = null;

    private int levelLengthMultiplier = 60;

    private void Awake()
    {
        SetDefaults();
    }
    
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        levelLengthSlider.value = PlayerPrefsController.GetMasterLength();
    }

    /*
     * Saves the changes made in Options to the PlayerPrefs using PlayerPrefsController
     */
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);        // Save volume value
        PlayerPrefsController.SetMasterLevelLength(levelLengthSlider.value);    // Save level length value
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        levelLengthSlider.value = defaultLevelLength;
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

    public void SetLevelLength()
    {
        int lengthInt = Mathf.RoundToInt(levelLengthSlider.value * levelLengthMultiplier + 30);
        levelSettings.SetLevelLength(lengthInt);
        UpdateLevelLengthText(lengthInt);
    }

    public void UpdateLevelLengthText(int levelLength)
    {
        levelLengthText.text = "LEVEL LENGTH: " + levelLength;
    }
}
