using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeetPeggy : MonoBehaviour {

	public GameObject teacup;
	public GameObject peggy;
	public GameObject teacupDialogue;
	public GameObject peggyDialogue;
	public GameObject userPrompt;
	public int cueUserPrompt;
	public int cueEnter;

	private int index = 0;
	private ArrayList dialogue = new ArrayList();

	//teacup is even
	//peggy is odd (numbers, personality too but hey)

	void Start () {
		AddDialogue ();
		teacupDialogue.SetActive (true);
		peggyDialogue.SetActive (false);
	}

	void Update () {
		
		if (Input.GetKeyDown ("space") && index <= dialogue.Count) {
			DialogueChange (index);
			index += 1;
		}
		if (index > 11 && Input.GetKeyDown ("return")) {
			SceneManager.LoadScene (6);
		}
	}

	void DialogueChange(int ind){
		if (ind % 2 == 0 && ind < dialogue.Count) {
			peggyDialogue.SetActive (false);
			teacupDialogue.SetActive (true);
			teacupDialogue.GetComponentInChildren<Text> ().text = (string)dialogue [index];		
		}
		if (ind % 2 != 0 && ind < dialogue.Count) {
			teacupDialogue.SetActive (false);
			peggyDialogue.SetActive (true);
			peggyDialogue.GetComponentInChildren<Text> ().text = (string)dialogue [index];
		} 
		if (ind == cueUserPrompt) {
			userPrompt.SetActive (true);
			userPrompt.GetComponentInChildren<Text> ().text = "Move to help this table if you feel so inclined. (You are inclined.)";
		}
		if (ind == cueEnter) {
			userPrompt.SetActive (true);
			userPrompt.GetComponentInChildren<Text> ().text = "Press Enter near the table to help.";
		}

	}
	void AddDialogue()
	{
		dialogue.Add ("Well hey, I did it! Guess that horse was a little of his rocker. HA!");
		dialogue.Add ("@#$!@#$%@");
		dialogue.Add ("What in the world!");
		dialogue.Add ("*translated pirate curses* ARGH! Would you do me a favor me matey?");
		dialogue.Add ("Of course! I am a hero on an adventure!");
		dialogue.Add ("Oh great. We got arghselves a hero. Can you cut me out with that chip you got there?");
		dialogue.Add ("(I should be more heroic!) But of course... my lady.");
		dialogue.Add ("My lady? Oh matey you've got yurself a lots to learn. Get me down from here and I'll show you how to survive in this world.");
		dialogue.Add ("*The horse's voice echoes in your head* There's a time and place for everything. Now is the time!");
		dialogue.Add ("Today please!");
		dialogue.Add ("Ah yes of course, fair maiden.");
		dialogue.Add ("ARGHARHAR! Maiden! Make that mistake again and I'll shatter you into a piece of eight!");
		dialogue.Add ("Noted.");
	
	}
}
