using UnityEngine;
using UnityEngine.SceneManagement; //use this library to enable SceneManager
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// start and exit buttons for title screen
/// </summary>
public class IntroScreenButtons : MonoBehaviour {

	public GameObject buttonPanel;
	public GameObject loadScreen;

	void Start()
	{
		loadScreen.SetActive (false);
	}
	public void OnClickLoad(){
		loadScreen.SetActive (true);
		SceneManager.LoadScene (2);
	}
	//only works in builds, not in the editor
	public void OnClickExit(){
		Application.Quit ();
	}

}
