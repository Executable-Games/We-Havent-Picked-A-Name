using UnityEngine;
using System.Collections;

public class CameraZoomChalkboard : MonoBehaviour {

	public float camerax = 1;
	public float cameray = 1;
	public float camerawidth = 2;
	public float cameraheight = 2;

	private Camera mainCamera;

	// Use this for initialization
	void Start () {
		GameObject chalkboard = GameObject.Find("EmptyChalkboard");

		mainCamera = GetComponent<Camera> ();
		camerax = chalkboard.transform.localPosition.x;
		cameray = chalkboard.transform.localPosition.y;
		camerawidth = chalkboard.transform.localPosition.x + 100;
		cameraheight = chalkboard.transform.localPosition.y + 100;


	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("space"))
		{
			mainCamera.orthographicSize *= 100;
			//mainCamera.rect = new Rect(camerax ,cameray ,camerawidth, cameraheight);
		}
	}
}
