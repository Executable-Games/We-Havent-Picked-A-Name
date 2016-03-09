using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;


public class ChoiceButtonsSpiders : MonoBehaviour {

    public GameObject option1Panel;
    public GameObject option2Panel;
    public GameObject option3Panel;
    public GameObject option4Panel;
    public SpidersCombat combat;
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
            timer.After (0.5f, goWin);
        }
        if (loseChoice == true) {
            timer.After (0.5f, goLose);
        }
    }

    public void goWin(){
        winPanel.SetActive (true);
    }
    public void goLose(){
        losePanel.SetActive (true);
    }

    public void TriggerZeroOne(){
        combat.changeTrack(1);
    }
    public void TriggerZeroTwo(){
        combat.changeTrack (4);
    }
    public void TriggerOneOne(){
        combat.changeTrack (2);
    }
    public void TriggerOneTwo(){
        combat.changeTrack (3);
    }
    public void TriggerTwoOne(){
        loseChoice = true;
        losePanel.GetComponentInChildren<Text> ().text = "You died. That was pretty stupid on your part. I even double checked if you were sure. This one’s all on you.";
    }
    public void TriggerTwoTwo(){
        loseChoice = true;
        losePanel.GetComponentInChildren<Text> ().text = "The spiders swarmed you and you died. I know, kind of unexpected. But that's life I suppose. *sigh*";

    }
    public void TriggerThreeOne(){
        loseChoice = true;
        losePanel.GetComponentInChildren<Text> ().text = "You died. I mean, there are quite a few of them. Your lady died too. You both totally got eaten. Jesus you’re an idiot.";
    }
    public void TriggerThreeTwo(){
        winChoice = true;
        winPanel.GetComponentInChildren<Text> ().text = "*spiders look kind of confused* \nYou run past them in their confusion, and have escaped! Great job, you filthy coward.";
    }
    public void TriggerFourOne(){
        loseChoice = true;
        losePanel.GetComponentInChildren<Text> ().text = "There are like 30 of them. You definitely died. You’re a terrible strategist.";
    }
    public void TriggerFourTwo(){
        combat.changeTrack (5);
    }
    public void TriggerFiveOne(){
        loseChoice = true;
        losePanel.GetComponentInChildren<Text> ().text = "You died. Did you really think provoking the spider gang would be a good idea? Doofus.";
    }
    public void TriggerFiveTwo(){
        combat.changeTrack (6);
    }
    public void TriggerSixOne(){
        winChoice = true;
        winPanel.GetComponentInChildren<Text> ().text = "*spiders nod excitedly and hurry away* \nGood job matey! You helped a few stray spiders who were down on their luck. What a mensch!";
    }
    public void TriggerSixTwo(){
        winChoice = true;
        winPanel.GetComponentInChildren<Text> ().text = "*spiders guiltily look to the ground and mumble something about you not being their ‘mother’*\nHey, nice going! You guilt-tripped the spider gang into letting you pass. Don’t be too happy though. It was still kind of a dick move on your part.";
    }
}
