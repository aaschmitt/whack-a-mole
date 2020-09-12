using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopher : MonoBehaviour
{
    private float _lifetime;
    
    // Start is called before the first frame update
    private void Start()
    {
        _lifetime = Random.Range(1f,3f);                                      // Set a random lifetime for the gophers
        StartCoroutine(WaitAndDestroy());                              // Start lifetime routine of gophers   
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(_lifetime);                           // Gopher will be alive for {lifetime} seconds, then destroyed
        Destroy(this.gameObject);
    }
}
