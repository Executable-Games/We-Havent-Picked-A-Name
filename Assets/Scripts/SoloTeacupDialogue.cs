using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SoloTeacupDialogue : MonoBehaviour {

	public GameObject teacup;
	public GameObject spider;
	public GameObject teacupDialogue;
	public GameObject spiderDialogue;
	public GameObject userPrompt;

	public int cueMovePrompt;
	public int cueJoke;
	public int cueFightPrompt;

	private int index = 1;


	private ArrayList dialogue = new ArrayList();

	//teacup is even
	//spider is odd

	void Start () {
		AddDialogue ();
		teacupDialogue.SetActive (true);
		spiderDialogue.SetActive (false);
		userPrompt.SetActive (false);
	}
	
	void Update () {
		if (Input.GetKeyDown ("space") && index <= dialogue.Count) {
			DialogueChange (index);
			index += 1;
		}
	}

	void AddDialogue(){
		dialogue.Add ("Wuh oh. How do I move?");
		dialogue.Add ("*spider sounds*");
		dialogue.Add ("Double wuh oh. An enemy! *ahem* Excuse me, um, ma'am (?) I need to pass.");
		dialogue.Add ("*stares*");
		dialogue.Add ("Well, I have things to do, things to fight, things to save, all that... So... Excuse me.");
		dialogue.Add ("*spider sounds*");
		dialogue.Add ("I see. I GUESS IT'S FIGHT TIME SPINSTER!");
		dialogue.Add ("*angry spider sounds*");
	}

	void DialogueChange(int ind){
		if (ind % 2 == 0 && ind < dialogue.Count){
			spiderDialogue.SetActive (false);
			teacupDialogue.SetActive(true);
			teacupDialogue.GetComponentInChildren<Text> ().text = (string)dialogue[index];		
		}
		if (ind % 2 != 0 && ind <= dialogue.Count) {
			teacupDialogue.SetActive (false);
			spiderDialogue.SetActive (true);
			spiderDialogue.GetComponentInChildren<Text> ().text = (string)dialogue [index];
		} 
		if (ind == cueMovePrompt) {
			userPrompt.SetActive (true);
			userPrompt.GetComponentInChildren<Text> ().text = "Press WASD to move";
		}
		if (ind == cueJoke) {
			userPrompt.GetComponentInChildren<Text> ().color = Color.blue;
			userPrompt.GetComponentInChildren<Text> ().text = "This spider is not about letting you enter the Hallow Zone.";
		}
		if (ind == cueFightPrompt) {
			userPrompt.GetComponentInChildren<Text> ().color = Color.red;
			userPrompt.GetComponentInChildren<Text> ().text = "Press Enter when the spider is red with rage.";
		}

	}

}
