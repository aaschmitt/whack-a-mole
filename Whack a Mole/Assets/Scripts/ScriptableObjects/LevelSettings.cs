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
    public float minSecondsToSpawn = 2f;
    public float maxSecondsToSpawn = 5f;
    public int minGopherLifetime, maxGopherLifetime = 0;

    private void OnEnable()
    {
        switch (levelDifficulty)
        {
            case LevelDifficulty.Easy:
                minGopherLifetime = 3;
                maxGopherLifetime = 6;
                break;
            case LevelDifficulty.Normal:
                minGopherLifetime = 2;
                maxGopherLifetime = 3;
                break;
            case LevelDifficulty.Hard:
                minGopherLifetime = 1;
                maxGopherLifetime = 2;
                break;
            default:
                break;
        }
    }
}
