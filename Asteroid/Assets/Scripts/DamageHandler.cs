using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public GameObject[] playerLife;
    
    public int health = 1;

    public int scoreValue;
    private GameController gameController;
    private SpawnStarScript starSpawner;

    public GameObject explosion;
    public GameObject playerExplosion;

    void Start()
    {

        GameObject spawnStarScriptObject = GameObject.FindWithTag("Stars");
        if(spawnStarScriptObject != null)
        {
            starSpawner = spawnStarScriptObject.GetComponent<SpawnStarScript>();
        }

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find gamecontroller script");
        }

        if (gameObject.tag == "Player")
        {
            gameController.changeHealth(health);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Stars")
        {
            health--;
        }

        if(gameObject.tag == "Player" && other.tag != "Stars")
        {
            gameController.changeHealth(health);
        }

        if (health <= 0)
        {
            if (other.tag != "Destroyer")
            {
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                gameController.AddScore(scoreValue);
                GetComponent<AudioSource>().Play();

                if(gameObject.tag == "Stars")
                {
                    starSpawner.AddStarScore(1);
                }
            }
            
			if(gameObject.tag=="Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }

			Destroy(gameObject);
        }
    }
}
