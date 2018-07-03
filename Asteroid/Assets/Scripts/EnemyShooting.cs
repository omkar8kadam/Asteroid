using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    public float fireDelay = 0.25f;
    float coolDownTimer = 0;

    // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;

        if (coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
