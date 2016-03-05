using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoloTeacupCombat : MonoBehaviour {

	public GameObject battlePrompt;
	public GameObject enemyInfo;
	public GameObject teacupDialogue;
	public GameObject choicePanel;
	public Timer timer;

	private int index = 0;
	private ArrayList dialogue = new ArrayList ();

	void Start () {
		AddDialogue ();
		choicePanel.SetActive(false);
		teacupDialogue.SetActive (true);
		teacupDialogue.GetComponentInChildren<Text> ().text = (string)dialogue[index];		
		battlePrompt.SetActive (true);
		battlePrompt.GetComponentInChildren<Text> ().text = "Welcome to combat. Be prepared to think";
		enemyInfo.SetActive (false);
	}

	void Update () {
		if (Input.GetKeyDown ("space")) {
			index += 1;
			DialogueChange (index);

		}
	}
	void DialogueChange(int ind){
		
		teacupDialogue.GetComponentInChildren<Text> ().text = (string)dialogue[index];		

		if (ind == 1) {
			battlePrompt.GetComponentInChildren<Text> ().text = "press spacebar.";

		}
		if (ind == 2) {
			battlePrompt.GetComponentInChildren<Text> ().text = "Welcome to combat. Be prepared to think quick and chortle quietly to yourself. Know your self. Know your enemy. Actually here, check out this oversized information box.";
			enemyInfo.SetActive (true);
		}
		if (ind == 5) {
			
			timer.After (1f, TriggerChoice);

		}

	}
		
	void AddDialogue(){
		dialogue.Add ("Oh wow that's useful.");
		dialogue.Add ("Wait I think there is more info. Press the spacebar and squint.");
		dialogue.Add ("Thanks. Let's see...");
		dialogue.Add ("Makes spider sounds... mm hm.");
		dialogue.Add ("Not my type. True, it's not plastic.");
		dialogue.Add ("Well, what to do?");
	}
	void TriggerChoice()
	{
		choicePanel.SetActive (true);
        teacupDialogue.SetActive(false);

	}

}
