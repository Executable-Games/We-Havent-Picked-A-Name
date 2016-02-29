using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChoiceButtons : MonoBehaviour {

	public GameObject option1Panel;
	public GameObject option2Panel;
	public GameObject option3Panel;
	public GameObject option4Panel;
	public GameObject winPanel;
	public GameObject losePanel;

	public void TriggerOne(){
		option1Panel.SetActive (true);
		winPanel.SetActive (true);
	}
	public void TriggerTwo(){
		option2Panel.SetActive (true);
		losePanel.SetActive (true);
	}
	public void TriggerThree(){
		option3Panel.SetActive (true);
		winPanel.SetActive (true);
	}
	public void TriggerFour(){
		option4Panel.SetActive (true);
		losePanel.SetActive (true);
	}
}
