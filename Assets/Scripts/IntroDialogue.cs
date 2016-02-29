using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Intro dialogue. This is a mish-mash script with one purpose - execute the very first, spacebar-only scene in the game, and lead into world scene
/// Author: Haley De Boom 2/21/16
/// </summary>
public class IntroDialogue : MonoBehaviour {

	//Is this a hot mess of public variables? Yes, yes it is. But it gets rid of the Find() calls that slow down the system

	public GameObject teacup;
	public GameObject rockingHorse;
	public GameObject teacupDialogue;
	public GameObject rockingHorseDialogue;
	public GameObject chalkboard;
	public GameObject userPrompt;
	public GameObject heroMusic;
	public GameObject LoadingScreen;
	public Vector3 adjust = new Vector3(); //How far the teacup is shifted on the screen after the chalkboard expands

	public int musicCue; //at what point in the dialogue the music begins
	public int stopDialogue; //the point when the dialogue stops (and the next scene is loaded)

	private int index = 0;
	private ArrayList dialogue = new ArrayList(); 

	void Start () {
		
		AddDialogue (); 
		userPrompt.GetComponentInChildren<Text> ().text = "How long has it been?";
		StartCoroutine (ShowPrompt ()); //begin timed functions
		teacupDialogue.SetActive (false); //double check that dialogue boxes are disabled
		rockingHorseDialogue.SetActive (false);
	}

	void Update () {

		if (Input.GetKeyDown ("space")) {
			DialogueChange (index);
			index += 1;
			ShowPrompt ();
		}
		if (index == stopDialogue) {
			StartCoroutine (StopDialogue ());
		}
	}

	IEnumerator ShowPrompt()
	{
		yield return new WaitForSeconds (4f);
		userPrompt.GetComponentInChildren<Text> ().text = "Press Spacebar to Continue"; // timed to switch once the chalkboard expands
		teacup.GetComponent<RectTransform> ().localPosition = chalkboard.GetComponent<RectTransform> ().localPosition + adjust; //move teacup at the end of chalkboard expansion
	}
		
	IEnumerator StopDialogue(){
		LoadingScreen.SetActive (true);
		yield return new WaitForSeconds (2f);
		LoadingScreen.SetActive (true);
		SceneManager.LoadScene(3);
	}

	void DialogueChange(int ind){

		//alternate between rocking horse and teacup dialogue
		if (ind % 2 == 0 && ind < stopDialogue){
			teacupDialogue.SetActive (false);
			rockingHorseDialogue.SetActive(true);
			rockingHorseDialogue.GetComponentInChildren<Text> ().text = (string)dialogue[index];		
		}
		if (ind % 2 != 0 && ind <= stopDialogue) {
			rockingHorseDialogue.SetActive (false);
			teacupDialogue.SetActive (true);
			teacupDialogue.GetComponentInChildren<Text> ().text = (string)dialogue [index];
		} 

		//remove chalkboard once dialogue starts
		if (ind == 1) {
			chalkboard.SetActive (false);
		}
		if (ind == musicCue) {
			heroMusic.SetActive (true);
		}
	}

	//redundant function but the lines would be added everytime the scene is instantiated anyway so at least it looks readable. Teacup lines are odd index lines, and the rocking horse is even
	void AddDialogue(){
		dialogue.Add ("Hey there Teacup, what brings you all the way over here?");
		dialogue.Add ("I'm going to escape!");
		dialogue.Add ("After all this time? Huh. Seems like you could have, you know, started sooner");
		dialogue.Add ("Better late than never!");
		dialogue.Add ("I mean sure, but like, what have you been doing this whole time?");
		dialogue.Add ("Moping! And training! But mostly moping!");
		dialogue.Add ("Well, now that you've decided to make an effort, good luck! It won't be eas-");
		dialogue.Add ("I know, but I have the heart of a hero!");
		dialogue.Add ("You didn't let me finish.");
		dialogue.Add ("Oh, sorry.");
		dialogue.Add ("So as I was say-");
		dialogue.Add ("But I just know I can do it! I'm going to save the day!");
		dialogue.Add ("Fine don't listen to me.");
		dialogue.Add ("Oh no I'm so sorry! I'm listening.");
		dialogue.Add ("...");
		dialogue.Add ("I am, I swear!");
		dialogue.Add ("Ok, just watch out for th-");
		dialogue.Add ("I'M GOING ON AN ADVENTURE!");
		dialogue.Add ("SERIOUSLY?");
		dialogue.Add ("Oh man I just - No, I'm sorry. That was rude.");
		dialogue.Add ("No, forget it. You're done. Good Luck, It's dangerous to go alone - find some friends to take the fights on for you. Remember, you are fine china.");
		dialogue.Add ("Good point. Thanks! HERE I GOOOO!");

	}
}
