using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Gopher
{
    [SerializeField] ParticleSystem[] explosionParticleSystems = null;
    [SerializeField] private Transform explodePoint = null;
    
    public override void SpawnClickEffect()
    {
        Vector3 pos = explodePoint.position;
        foreach (ParticleSystem effect in explosionParticleSystems)
        {
            Instantiate(effect, pos, Quaternion.identity);
        }
    }
}
