using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class IntroScreenButtons : MonoBehaviour {


	public void OnClickLoad(){

		SceneManager.LoadScene (1);
	}
	public void OnClickExit(){
		Application.Quit ();
	}

}
