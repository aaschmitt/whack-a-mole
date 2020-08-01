using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopher : MonoBehaviour
{

    // instance variables
    public LevelManager levelManager;
    private IEnumerator waitAndDestroy;
    private int lifetime;
    private int pointsOnDeath;
    
    // customizable constructor
    public Gopher(int lifetime, int pointsOnDeath) {

        this.lifetime = lifetime;
        this.pointsOnDeath = pointsOnDeath;

    }

    // default constructor
    public Gopher() {

        lifetime = 2;
        pointsOnDeath = 3;

    }

    // Start is called before the first frame update
    void Start() {

       waitAndDestroy = WaitAndDestroy();
       StartCoroutine(waitAndDestroy);

    }

    // Destroy the object and update score if clicked
    void OnMouseDown() {

        Destroy(this.gameObject);
        levelManager.AnnounceGopherDeath(pointsOnDeath);

    }

    IEnumerator WaitAndDestroy() {

        yield return new WaitForSeconds(lifetime);

        // Destroy gopher if not clicked during lifetime
        Destroy(this.gameObject);

    }

}
