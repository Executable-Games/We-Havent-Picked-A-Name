using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChoicePanelButtons : MonoBehaviour {

	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public string button1Text;
	public string button2Text;
	public string button3Text;
	public string button4Text;

	void Start () {
		button1.GetComponent<Text> ().text = button1Text;
		button2.GetComponent<Text> ().text = button2Text;
		button3.GetComponent<Text> ().text = button3Text;
		button4.GetComponent<Text> ().text = button4Text;
	}

}
