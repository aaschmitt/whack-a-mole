using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopher : MonoBehaviour
{

    private IEnumerator waitAndDestroy;
    private int lifetime;
    
    public Gopher(int lifetime) {

        this.lifetime = lifetime;

    }

    public Gopher() {

        lifetime = 2;

    }

    // Start is called before the first frame update
    void Start()
    {
       waitAndDestroy = WaitAndDestroy();
       StartCoroutine(waitAndDestroy);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // Destroy the object if clicked
    void OnMouseDown() {

        Destroy(this.gameObject);

    }

    IEnumerator WaitAndDestroy() {

        yield return new WaitForSeconds(lifetime);

        // Destroy gopher if not clicked during lifetime
        Destroy(this.gameObject);

    }
}
