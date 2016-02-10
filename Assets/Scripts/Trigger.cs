using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject Target;
	public Material TargetMaterial;


	// Use this for initialization
	void Start () {
		TargetMaterial.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D col)
	{
		TargetMaterial.color = Color.yellow;
		if (Input.GetKey (KeyCode.Space))
			TargetMaterial.color = Color.green;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		TargetMaterial.color = Color.red;

	}


}
