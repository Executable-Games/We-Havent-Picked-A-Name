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
        //option2Panel.SetActive (true);
        //loseChoice = true;
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
        winPanel.GetComponentInChildren<Text> ().text = "*spiders look kind of confused* You run past them in their confusion, and have escaped! Great job, you filthy coward.";
    }
}
