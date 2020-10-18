using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Gopher
{
    [SerializeField] private ParticleSystem explosionParticleSystem = null;

    void OnDestroy()
    {
        Instantiate(explosionParticleSystem, this.transform);
    }
}
