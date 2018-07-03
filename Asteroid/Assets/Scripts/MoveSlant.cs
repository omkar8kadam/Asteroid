using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSlant : MonoBehaviour {

    public float maxSpeed = 1f;
    private int flg = 0;
    public float delay = 2f;
    private float start;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= maxSpeed * Time.deltaTime;
        pos.y += maxSpeed * Time.deltaTime;
        transform.position = pos;
        if (flg == 1)
        {
            if (Time.time - start >= delay)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        flg = 1;
        start = Time.deltaTime;
    }
}
