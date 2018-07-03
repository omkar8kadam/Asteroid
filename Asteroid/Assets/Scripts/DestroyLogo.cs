using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyLogo : MonoBehaviour {

    public int health = 1;
    public GameObject explosion;
    public GameObject presents;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(presents);
            Instantiate(explosion, transform.position, transform.rotation);
            
        }
    }
}
