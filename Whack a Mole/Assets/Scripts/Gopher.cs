using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gopher : MonoBehaviour
{
    public float Lifetime { get; set; }
    public int score = 0;
    public float disableSpawnerTime = 0;
    
    [SerializeField] private ParticleSystem gopherClickParticleEffect = null;
    private Animator _animator = null;

    private void Start()
    {
        _animator = GetComponent<Animator>();                                 // Get the animator component
        StartCoroutine(WaitAndDestroy());                              // Start lifetime routine of gophers   
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(Lifetime);                            // Gopher will be alive for {lifetime} seconds, then destroyed
        Despawn();
    }

    public void Despawn()
    {
        // By setting the animation to Gopher_Despawn, the gopher will automatically destroy itself when finishing with the animation. (See 'DestroyOnExit' script)
        _animator.SetBool("despawnsWithoutClick", true);                         // Trigger the "despawning" animation by setting the bool parameter in the Gopher animator controller
    }

    public virtual void SpawnClickEffect()
    {
        Vector3 pos = this.transform.position;
        Instantiate(gopherClickParticleEffect, pos, Quaternion.identity);
    }
}
