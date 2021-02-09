using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan1 : MonoBehaviour {

	public float speed = 4.0f;

	private Vector2 direction = Vector2.zero;
	public bool Life1 =true;
	public bool Life2 =true;
	public bool Life3 =true;
	
	void Update () 
	{

		CheckInput ();

		Move ();

		UpdateOrientation ();
	}

	void CheckInput () 
	{

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			direction = Vector2.left;

		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {

			direction = Vector2.right;

		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {

			direction = Vector2.up;

		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {

			direction = Vector2.down;
		}
	}

	void Move () 
	{

		transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
	}

	void UpdateOrientation () 
	{

		if (direction == Vector2.left) {

			transform.localScale = new Vector3 (-1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 0);

		} else if (direction == Vector2.right) {

			transform.localScale = new Vector3 (1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 0);

		} else if (direction == Vector2.up) {

			transform.localScale = new Vector3 (1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 0);

		} else if (direction == Vector2.down) {

			transform.localScale = new Vector3 (1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 0);
		}

	}
	public void DestroySelf()
	{
		Destroy(gameObject);
	}
	void LifeTracker()
	{
		if(Life3==true)
		{
			return;
		}
		else
		{
			if(Life2==true)
			{
				return;
			}
			else
			{
				if(Life1==true)
				{
					return;
				}
				else
				{
					
				}
			}
		}
	}
}
