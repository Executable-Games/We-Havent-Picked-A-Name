using UnityEngine;
using System.Collections;

public class EasyMove : MonoBehaviour {

	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;
	private float movexChange = 0f;
	public float desiredScale =0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A))
			movex = -1;
		else if (Input.GetKey (KeyCode.D))
			movex = 1;
		else
			movex = 0;
		if (Input.GetKey (KeyCode.W)) {
			transform.localScale += new Vector3 (-desiredScale, -desiredScale, 0f);
			movexChange = 0.9f;
			movey = 1;
		} else if (Input.GetKey (KeyCode.S)) {
			transform.localScale += new Vector3 (desiredScale, desiredScale, 0f);
			movey = -1;
			movexChange = 1.1f;
		}
		else
			movey = 0;
	}

	void FixedUpdate ()
	{

		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * movexChange * Speed, movey * Speed);
	}



}