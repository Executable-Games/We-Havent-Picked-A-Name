using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ZoomSplash : MonoBehaviour {
	
	public Vector2 increaseSpeed = new Vector2();
	public float repeatValue;
	public GameObject image;
	public GameObject text;
	public AudioSource dave;

	void Start (){
		StartCoroutine (ImmediateZoom());
	}

	void Zoom(){
		this.GetComponent<RectTransform> ().sizeDelta += increaseSpeed;
		image.GetComponent<RectTransform> ().sizeDelta += increaseSpeed;
	}

	IEnumerator ImmediateZoom()
	{
		yield return new WaitForSeconds (0.25f);
		InvokeRepeating("Zoom", repeatValue, .05f);
		yield return new WaitForSeconds (2.5f);
		CancelInvoke ();
		dave.Play ();
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (1);
	}
}
