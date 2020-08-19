using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopher : MonoBehaviour
{
    private int _lifetime;
    private int _pointsOnDeath;

    Gopher(int lifetime, int pointsOnDeath) {
        _lifetime = lifetime;
        _pointsOnDeath = pointsOnDeath;
    }

    Gopher() {
        _lifetime = 2;
        _pointsOnDeath = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when a gopher is clicked
    void OnMouseDown() {
        // Announce a gopher has been clicked
        // Destroy the gopher
    }
}
