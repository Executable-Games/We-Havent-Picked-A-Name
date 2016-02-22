using UnityEngine;
using UnityEngine.SceneManagement; //use this library to enable SceneManager
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// start and exit buttons for title screen
/// </summary>
public class IntroScreenButtons : MonoBehaviour {

	public void OnClickLoad(){
		SceneManager.LoadScene (1);
	}
	//only works in builds, not in the editor
	public void OnClickExit(){
		Application.Quit ();
	}

}
