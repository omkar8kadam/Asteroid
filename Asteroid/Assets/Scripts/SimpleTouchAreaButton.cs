using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool touched;
    private int pointerID;
    private bool canFire;
	private bool moveLeft;
	private bool moveRight;

	void Awake()
    {
        touched = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
            canFire = true;
			moveLeft = true;
			moveRight = true;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            canFire = false;
			moveLeft = false;
			moveRight = false;
            touched = false;
        }
    }

    public bool CanFire()
    {
        return canFire;
    }

	public bool CanMoveLeft()
	{
		return moveLeft;
	}

	public bool CanMoveRight()
	{
		return moveRight;
	}
}
