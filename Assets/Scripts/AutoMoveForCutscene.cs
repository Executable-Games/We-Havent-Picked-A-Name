using UnityEngine;
using System.Collections;

public class AutoMoveForCutscene : MonoBehaviour {

	public float speed;
	public float stopRight;
	public float stopUp;

	void Start(){

	}
	void Update () {
	
		if (transform.localPosition.x <= stopRight)
			MoveRight ();
		if (transform.localPosition.y <= stopUp)
			MoveUp ();
			
	}

	void MoveRight(){
		transform.localPosition += transform.right * speed * Time.deltaTime;

	}
		
	void MoveUp(){
		transform.localPosition += transform.up * speed * Time.deltaTime;
	}
}
