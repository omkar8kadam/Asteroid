using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    public float fireDelay = 0.25f;
    float coolDownTimer = 0;
    public SimpleTouchAreaButton areaButton;
    public SimpleTouchAreaButton areaButton1;

    // Update is called once per frame
    void Update ()
    {
        coolDownTimer -= Time.deltaTime;
        
        if(/*Input.GetButton("Fire1")*/(areaButton.CanFire() || areaButton1.CanFire()) && coolDownTimer <= 0)
        {
            coolDownTimer = fireDelay;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
	}

	public void shoot()
	{
		Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
	}
}
