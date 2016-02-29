	using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This causes the size of the chalkboard to increase, and for a switch between the tally-mark board and the board with text
/// Author: Haley De Boom 2/21/16
/// </summary>
public class ZoomChalkboard : MonoBehaviour {

	//the higher the increase speed, the faster the zoom (and thus the larger the result)

	public Vector2 increaseSpeed = new Vector2();
	public GameObject emptyChalkboard;
	public GameObject exposition;

	//The moment this script is loaded the function SmoothZoom (with a timer element) begins
	void Start (){
		StartCoroutine (SmoothZoom());
	}

	//the basic concept of chaning size, just not over time. Enables it to be called in a repeating function
	void Zoom(){
		this.GetComponent<RectTransform> ().sizeDelta += increaseSpeed;
		emptyChalkboard.GetComponent<RectTransform> ().sizeDelta += increaseSpeed;
	}
		
	//as an IENumerator and not a void function you can use WaitForSeconds. also switches chalkboards once it is the proper size
	IEnumerator SmoothZoom()
	{
		yield return new WaitForSeconds (1.5f);
		InvokeRepeating("Zoom", 2, .05f);
		yield return new WaitForSeconds (2.5f);
		CancelInvoke ();
		emptyChalkboard.SetActive (true);
		exposition.SetActive (true);

	}
}
