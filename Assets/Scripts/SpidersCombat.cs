using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SpidersCombat : MonoBehaviour {

    public GameObject battlePrompt;
    public GameObject enemyInfo;
    public GameObject teacupDialogue;
    public GameObject spiderDialogue;
    public GameObject choicePanel1;
    public GameObject choicePanel2;
    public GameObject choicePanel3;
    public GameObject choicePanel4;
    public GameObject choicePanel5;
    public GameObject choicePanel6;
    public GameObject choicePanel7;
    public Timer timer;

    private int index = 0;
    private int current_track = 0;
    private ArrayList dialogue = new ArrayList ();
    private bool switchNow;
    void Start () {
        AddDialogue ();
        choicePanel1.SetActive(false);
        choicePanel2.SetActive(false);
        choicePanel3.SetActive(false);
        choicePanel4.SetActive (false);
        choicePanel5.SetActive (false);
        choicePanel6.SetActive (false);
        choicePanel7.SetActive (false);
        teacupDialogue.SetActive (true);
        teacupDialogue.GetComponentInChildren<Text> ().text = (string)dialogue[index];
        spiderDialogue.SetActive(true);
        spiderDialogue.GetComponentInChildren<Text>().text = "*angry spider sounds*";
        battlePrompt.SetActive (true);
        battlePrompt.GetComponentInChildren<Text> ().text = "Welcome to combat (again!) IT'S GO TIME!";
        enemyInfo.SetActive (false);
    }

    void Update () {
        if (Input.GetKeyDown ("space")) {
            index += 1;
            DialogueChange (index);
        }
    }

    void DialogueChange(int ind){

        Debug.Log(ind);
        string dialogueToDisplay = (string)dialogue[ind];
        char empty = Convert.ToChar(" ");

        if (dialogueToDisplay[0] != empty)
        {
            spiderDialogue.SetActive(false);
            teacupDialogue.SetActive(true);
            teacupDialogue.GetComponentInChildren<Text>().text = dialogueToDisplay;
        }
        if (dialogueToDisplay[0] == empty)
        {
            teacupDialogue.SetActive(false);
            spiderDialogue.SetActive(true);
            spiderDialogue.GetComponentInChildren<Text>().text = dialogueToDisplay;
        }

        DialogueChangeAsWell(ind);
    }

    void DialogueChangeAsWell(int ind){
        if (ind == 0) {
            battlePrompt.GetComponentInChildren<Text> ().text = "When in doubt, space it out.";

        }
        if (ind == 1) {
            enemyInfo.SetActive (true);
        }
        if (ind == 2) {
            Debug.Log("GO!");
            timer.After (.5f, TriggerChoice);
        }
        if (current_track == 1 && ind == 5) {
            timer.After (1.5f, TriggerChoice);
        } else if (current_track == 2 && ind == 12) {
            timer.After (.5f, TriggerChoice);
        } else if (current_track == 3 && ind == 9) {
            timer.After (.5f, TriggerChoice);
        } else if (current_track == 4 && ind == 4) {
            timer.After (.5f, TriggerChoice);
        } else if (current_track == 5 && ind == 9) {
            timer.After (.5f, TriggerChoice);
        } else if (current_track == 6 && ind == 11) {
            timer.After (1f, TriggerChoice);
        }

    
    }
    void AddDialogue(){
        dialogue.Add ("Oh boy, a bunch of 'em!");
        dialogue.Add ("Hmm, this looks like a toughy.");
        dialogue.Add ("Do you want to talk to them, Peggy, or shall I?");

    }

    public void changeTrack(int ind){

        if (ind == 1) {
            choicePanel1.SetActive (false);
            teacupDialogue.SetActive(true);
            current_track = 1;
            dialogue.Add ("Hark, m'lady, it would appear that some scoundrels are blocking our path!");
            dialogue.Add ("State your purpose, you six-legged scoundrel!");
            dialogue.Add (" *spiders don’t say anything since spiders can’t talk*");
        }
        if (ind == 2) {
            choicePanel2.SetActive (false);
            teacupDialogue.SetActive(true);
            current_track = 2;
            dialogue.Add (" *spiders confidently swell their… abdomens? I guess?*");
            dialogue.Add (" *I’m not sure what the chest-part is called on spiders*");
            dialogue.Add ("Are you sure you want to battle? They appear to be heavily-armed…");
            dialogue.Add ("lol.");
            dialogue.Add ("Get it? Heavily-ARMED.");
            dialogue.Add ("Classic.");
            dialogue.Add ("Anyways, what's the plan?");
        }
        if (ind == 3) {
            choicePanel2.SetActive (false);
            teacupDialogue.SetActive(true);
            current_track = 3;
            dialogue.Add (" *spiders look a little confused. Hard to tell though, since they’re spiders and all*");
            dialogue.Add ("Harrumph.");
            dialogue.Add("My chivalrous nature dictates that I must battle you if you continue to show disdain towards m’lady.");
            dialogue.Add (" *spiders don’t do anything in particular to indicate disdain towards ur’lady*");
        }

        //Peggy dialogue
        if (ind == 4) {
            choicePanel1.SetActive (false);
            teacupDialogue.SetActive(true);
            current_track = 4;
            dialogue.Add ("Argh, what’r you lot looking at?");
            dialogue.Add (" *spiders scuttle threateningly*");
        }
        if (ind == 5) {
            choicePanel5.SetActive (false);
            teacupDialogue.SetActive(true);
            current_track = 5;
            dialogue.Add (" *spiders spread out and appear to take defensive positions*");
            dialogue.Add ("Looks like they’re making a pretty wide web!");
            dialogue.Add ("Maybe, a world-wide web!");
            dialogue.Add ("Har-har-har!");
            dialogue.Add ("So anyways….");
        }
        if (ind == 6) {
            choicePanel6.SetActive (false);
            teacupDialogue.SetActive(true);
            current_track = 6;
            dialogue.Add (" *spiders scuttle in reluctant agreement*");
            dialogue.Add ("I’ll tell you what, how about…");
        }
        index += 1;
        DialogueChange (index);
    }

    void TriggerChoice()
    {
        if (current_track == 0)
            choicePanel1.SetActive (true);
        else if (current_track == 1)
            choicePanel2.SetActive (true);
        else if (current_track == 2)
            choicePanel3.SetActive (true);
        else if (current_track == 3)
            choicePanel4.SetActive (true);
        else if (current_track == 4)
            choicePanel5.SetActive (true);
        else if (current_track == 5)
            choicePanel6.SetActive (true);
        else if (current_track == 6)
            choicePanel7.SetActive (true);
        teacupDialogue.SetActive(false);

    }

}
