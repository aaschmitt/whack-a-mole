using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{ 
    // PlayerPref keys
    private const string MASTER_VOLUME_KEY = "master volume";
    private const string MASTER_LEVELLENGTH_KEY = "master level length";
    
    // "master volume" PlayerPref restrictions
    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;
    
    // "master length" PlayerPref restrictions
    private const float MIN_LENGTH = 30f;
    private const float MAX_LENGTH = 90f;

    /*
     * Checks to see if supplied volume fits within restrictions, and sets the value of
     * MASTER_VOLUME_KEY to the new volume
     */
    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    /*
     * Returns the value associated with the MASTER_VOLUME_KEY
     */
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetMasterLevelLength(float lengthFraction)
    {
        float lengthInSeconds = lengthFraction * 60 + 30;
        
        if (lengthInSeconds >= MIN_LENGTH && lengthInSeconds <= MAX_LENGTH)
        {
            PlayerPrefs.SetFloat(MASTER_LEVELLENGTH_KEY, lengthFraction);
        }
        else
        {
            Debug.LogError("Master length is out of range");
        }
    }

    public static float GetMasterLength()
    {
        return PlayerPrefs.GetFloat(MASTER_LEVELLENGTH_KEY);
    }
}
