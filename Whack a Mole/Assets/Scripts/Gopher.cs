using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopher : MonoBehaviour
{
    public float Lifetime { get; set; }

    private void Start()
    {
        StartCoroutine(WaitAndDestroy());                              // Start lifetime routine of gophers   
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(Lifetime);                           // Gopher will be alive for {lifetime} seconds, then destroyed
        Destroy(this.gameObject);
    }
}
