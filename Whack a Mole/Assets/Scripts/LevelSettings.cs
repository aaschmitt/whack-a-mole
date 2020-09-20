using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelSettings : ScriptableObject
{
    public enum LevelDifficulty
    {
        Easy,
        Normal,
        Hard
    }

    public LevelDifficulty levelDifficulty;
    [Range(0, 180)] public int levelLengthInSeconds;
    [Range(0, 10)] public int scorePerGopher;

}
