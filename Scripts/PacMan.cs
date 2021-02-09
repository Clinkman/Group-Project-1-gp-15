using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PacMan : MonoBehaviour {

	public float speed = 4.0f;

	private Vector2 direction = Vector2.zero;

	public int live = 3;

	public GameObject Player;

	public static int gold = 0;

	public static int mode = 0;

	public float timeLeft = 10f;

	public AudioSource boom;

	public Animator animator;

	// Use this for initialization
	void Start () {
		lives.Number = live;
		
	}
	
	// Update is called once per frame
	void Update () {

		CheckInput ();

		Move ();

		UpdateOrientation ();

		if(gold >= 52)
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if(mode >= 1)
        {
			timeLeft -= Time.deltaTime;
        }
		if(timeLeft <= 0)
        {
			mode = 0;
			timeLeft = 10f;
        }
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Enemy"))
		{
			if (mode >= 1)
			{
				
			}
			else
			{
				if (live <= 1)
				{
					boom.Play();
					Destroy(gameObject);
					SceneManager.LoadScene(4);
				}
				boom.Play();
				Player.transform.position = new Vector3(-9, -5, -1);
				live -= 1;
				lives.Number = live;
			}
		}
	}


	void CheckInput () {

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

	void Move () {

		transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
	}

	void UpdateOrientation () {

		if (direction == Vector2.left) {

			transform.localScale = new Vector3 (-2, 2, 2);
			transform.localRotation = Quaternion.Euler (0, 0, 0);

		} else if (direction == Vector2.right) {

			transform.localScale = new Vector3 (2, 2, 2);
			transform.localRotation = Quaternion.Euler (0, 0, 0);

		} else if (direction == Vector2.up) {

			transform.localScale = new Vector3 (2, 2, 2);
			transform.localRotation = Quaternion.Euler (0, 0, 90);

		} else if (direction == Vector2.down) {

			transform.localScale = new Vector3 (2, 2, 2);
			transform.localRotation = Quaternion.Euler (0, 0, 270);
		}
	}
}

internal struct NewStruct
{
    public object Item1;
    public object Item2;

    public NewStruct(object item1, object item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public override bool Equals(object obj)
    {
        return obj is NewStruct other &&
               EqualityComparer<object>.Default.Equals(Item1, other.Item1) &&
               EqualityComparer<object>.Default.Equals(Item2, other.Item2);
    }

    public override int GetHashCode()
    {
        int hashCode = -1030903623;
        hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Item1);
        hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Item2);
        return hashCode;
    }

    public void Deconstruct(out object item1, out object item2)
    {
        item1 = Item1;
        item2 = Item2;
    }

    public static implicit operator (object, object)(NewStruct value)
    {
        return (value.Item1, value.Item2);
    }

    public static implicit operator NewStruct((object, object) value)
    {
        return new NewStruct(value.Item1, value.Item2);
    }
}