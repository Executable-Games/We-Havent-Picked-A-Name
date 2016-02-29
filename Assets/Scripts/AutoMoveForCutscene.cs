using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the teacup at the beginning of the intro scene, very touchy/magic numbery, but the Move function could be used elsewhere
/// Author: Haley De Boom 2/21/16
/// </summary>
public class AutoMoveForCutscene : MonoBehaviour {

	public float speed;
	public float stopRightDecimal; //should be between -2 and -0.5 , determines where(ish) the teacup stops moving to the right
	public float stopUpDecimal; //should be between 0 and 1, determines where(ish) the teacup stops moving upward

	void Update () {

		if (transform.localPosition.x <= (Screen.width / 2) * stopRightDecimal)
			MoveRight ();
		if (transform.localPosition.y <= (Screen.height/9) * stopUpDecimal)
			MoveUp ();
			
	}
	void MoveRight(){
		transform.localPosition += transform.right * speed * Time.deltaTime;

	}
	void MoveUp(){
		transform.localPosition += transform.up * speed * Time.deltaTime;
	}


}
