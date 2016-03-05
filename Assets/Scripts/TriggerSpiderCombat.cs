using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerSpiderCombat : MonoBehaviour {

	public GameObject Target;
	public Material TargetMaterial;
	public GameObject loadingScreen;

	void Start () {
		TargetMaterial.color = Color.black;
		loadingScreen.SetActive (false);
	}
	void Update(){
		if (TargetMaterial.color == Color.red && Input.GetKeyDown (KeyCode.Return))
		{
			loadingScreen.SetActive (true);
			Wait(5f);
			SceneManager.LoadScene (4);
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		TargetMaterial.color = Color.red;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		TargetMaterial.color = Color.black;

	}
	IEnumerator Wait(float seconds){
		yield return new WaitForSeconds (seconds);
	}

}