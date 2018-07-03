using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float maxSpeed = 5f;

	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = transform.position;
        pos.y += maxSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
