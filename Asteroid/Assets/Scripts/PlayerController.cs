using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public SimpleTouchAreaButton leftareaButton;
	public SimpleTouchAreaButton rightareaButton;

    public SimpleTouchAreaButton leftareaButton1;
    public SimpleTouchAreaButton rightareaButton1;

    private float y_val=0,x_val=0;
    public float disp=2f;
    Vector3 pos;

    public float maxSpeed = 5f;
    public SimpleTouchPad touchPad;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    //Vector2 direction = touchPad.GetDirection();
		if (leftareaButton.CanMoveLeft () || rightareaButton.CanMoveRight () || leftareaButton1.CanMoveLeft() || rightareaButton1.CanMoveRight()) 
		{
			if(leftareaButton.CanMoveLeft () || leftareaButton1.CanMoveLeft())
				x_val = -disp;
			if(rightareaButton.CanMoveRight () || rightareaButton1.CanMoveRight())
				x_val = disp;
			pos = transform.position;
			pos.y += /*Input.GetAxis("Vertical")direction.y*/ y_val * maxSpeed * Time.deltaTime;

			pos = transform.position;
			pos.x += /*Input.GetAxis("Horizontal")direction.x*/ x_val * maxSpeed * Time.deltaTime;
			transform.position = pos;

			transform.position = pos;

			pos = transform.position;
			if (pos.x >= 2.3f)
				pos.x = 2.3f;
			if (pos.x <= -2.3f)
				pos.x = -2.3f;
			if (pos.y <= -1.2f)
				pos.y = -1.2f;
			if (pos.y >= 4f)
				pos.y = 4f;
			transform.position = pos;
			pos = transform.position;
			transform.position = pos;

		} 
    }
}
