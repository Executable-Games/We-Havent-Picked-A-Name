using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class TeggyScript : MonoBehaviour {

    public GameObject teacup;
    public GameObject mainCamera;
    public GameObject teacupDialogue;
    public GameObject peggyDialogue;
    public GameObject userPrompt;
    public GameObject video;
    public GameObject LoadingScreen;

    
    public Timer timer;
    public int cueRandomVideo = 7;

    private int index = 0;
    private ArrayList dialogue = new ArrayList();

    void Start()
    {
        AddDialogue();
        userPrompt.GetComponentInChildren<Text>().text = "press spacebar to continue";
        teacupDialogue.SetActive(true); 
        peggyDialogue.SetActive(false);
        video.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            DialogueChange(index);
            index += 1;

        }
        if (teacup.transform.localPosition.x <= -300)
        {
                        userPrompt.GetComponentInChildren<Text>().text = "Your other right!";

        }
        if (teacup.transform.localPosition.x <= -500)
        {
            userPrompt.GetComponentInChildren<Text>().text = "Literally where are you going?";
        }
        if (teacup.transform.localPosition.x <= -700)
        {
            userPrompt.GetComponentInChildren<Text>().text = "We're not just going to load the scene anyway because you can't follow directions.";
        }
        if (teacup.transform.localPosition.x <= -1100)
        {
            userPrompt.GetComponentInChildren<Text>().text = "OMG FINE.";
            timer.After(1f, Load);
        }
        if(teacup.transform.localPosition.x >= 550)
        {
            LoadingScreen.SetActive(true);
            Load();
        }
        if (index == 7)
        {
            video.SetActive(true);
            Renderer r = video.GetComponent<Renderer>();
            MovieTexture movie = (MovieTexture)r.material.mainTexture;
            movie.Play();
            userPrompt.GetComponentInChildren<Text>().color = Color.red;
            userPrompt.GetComponentInChildren<Text>().text = "Move to right edge of screen to continue";

        }
    }

    void Load()
    {
        Renderer r = video.GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie.Stop();
        mainCamera.GetComponentInChildren<Light>().intensity = 0;
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(7);
    }
    void DialogueChange(int ind)
    {

        if (ind % 2 != 0)
        {
            teacupDialogue.SetActive(true);
            peggyDialogue.SetActive(false);
            teacupDialogue.GetComponentInChildren<Text>().text = (string)dialogue[index];
        }
        if (ind % 2 == 0)
        {
            peggyDialogue.SetActive(true);
            teacupDialogue.SetActive(false);
            peggyDialogue.GetComponentInChildren<Text>().text = (string)dialogue[index];
        }

    }
    void AddDialogue()
    {
        dialogue.Add("Argh, my name be Peggy not Sally! Peggy, the peg-legged pirate pizza table!");
        dialogue.Add("Would you say you're... unstable?");
        dialogue.Add("ARGH HAR HAR That would make me a - ");
        dialogue.Add("An unstable peg-legged pirate pizza table!");
        dialogue.Add("Has anyone evar told you you like to interrupt?");
        dialogue.Add("Actually - ");
        dialogue.Add("ARGH @#$%!#!");
        dialogue.Add("WHAT IS GOING ON?");
    }
}
