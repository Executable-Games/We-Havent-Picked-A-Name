using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;


public class ChoiceButtons : MonoBehaviour {

	public GameObject option1Panel;
	public GameObject option2Panel;
	public GameObject option3Panel;
	public GameObject option4Panel;
    public GameObject Combat;
	public GameObject winPanel;
	public GameObject losePanel;
	public Timer timer;
	private bool winChoice = false;
	private bool loseChoice = false;

	void Start(){
		winPanel.SetActive (false);
		losePanel.SetActive (false);
	}

	void Update(){
		
		if (winChoice == true) {
			timer.After (3f, goWin);
		}
		if (loseChoice == true) {
			timer.After (3f, goLose);
		}
	}

	public void goWin(){
		winPanel.SetActive (true);
	}
	public void goLose(){
		losePanel.SetActive (true);
	}

	public void TriggerOne(){
		option1Panel.SetActive (true);
		winChoice = true;
	}
	public void TriggerTwo(){
		option2Panel.SetActive (true);
		loseChoice = true;
	}
	public void TriggerThree(){
		option3Panel.SetActive (true);
		winChoice = true;
	}
	public void TriggerFour(){
		option4Panel.SetActive (true);
		loseChoice = true;
	}
}
