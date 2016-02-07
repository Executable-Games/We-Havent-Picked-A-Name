using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalWindow : MonoBehaviour {

    public Sprite icon;
    public Transform spawnPoint;

    public GameObject thingToSpawn;

    private ModalPanel modalPanel;
    private DisplayManager displayManager;

    private UnityAction myOpt1Action;
    private UnityAction myOpt2Action;
    private UnityAction myOpt3Action;
    private UnityAction myOpt4Action;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        displayManager = DisplayManager.Instance();

        //myOpt1Action = new UnityAction(TestOpt1);
        //myOpt2Action = new UnityAction(TestOpt2);
        //myOpt3Action = new UnityAction(TestOpt3);
    }

    //tell modal panel to set up buttons and functions to call
    public void TestOptions()
    {
        //modalPanel.PlayerChoice("Which Option would you like?\n Or something else perhaps?", myOpt1Action, myOpt2Action, myOpt3Action);
        modalPanel.PlayerChoice("Which Option would you like?\n Or something else perhaps?", TestOpt1, TestOpt2, TestOpt3);
    }

    //using PlayerGenChoice

    public void TestGenChoice()
    {
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails {question = "This is an announcement!\nIf you don't like it, shove off!" };
        modalPanelDetails.button1Details = new EventButtonDetails{buttonTitle = "Gotcha!", action = TestOpt3};

        modalPanel.PlayerGenChoice(modalPanelDetails);
    }
    public void TestOptions3WithImage()
    {
        modalPanel.PlayerChoice("Which Option would you like?\n Or something else perhaps?", icon, TestOpt1, TestOpt2, TestOpt3);
    }

    public void TestLambda()
    {
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "Do you want to create three things?" }; modalPanelDetails.button1Details = new EventButtonDetails
        {
            buttonTitle = "Yes Please!",
            action = () => { InstantiateObject(thingToSpawn); InstantiateObject(thingToSpawn, thingToSpawn); }
        };
        modalPanelDetails.button2Details = new EventButtonDetails
        {
            buttonTitle = "No thanks!",
            action = TestOpt2
        };

        modalPanel.PlayerGenChoice(modalPanelDetails);
    }

    //can double up the number of spawns by repeating lambda call: () => { InstantiateObject(thingToSpawn); InstantiateObject(thingToSpawn);}, TestOpt2);

    public void TestLambda2()
    {
        modalPanel.PlayerChoice("Do you want to spawn an object?", () => { InstantiateObject(thingToSpawn); }, TestOpt2);
    }

    void TestOpt1()
    {
        displayManager.DisplayMessage("WOO!");
    }
    void TestOpt2()
    {
        displayManager.DisplayMessage("Option2!");
    }
    void TestOpt3()
    {
        displayManager.DisplayMessage("HEEEY");
    }

    void InstantiateObject(GameObject thingToInstantiate)
    {
        displayManager.DisplayMessage("Here you go!");
        Instantiate(thingToInstantiate, spawnPoint.position, spawnPoint.rotation);
    }

    void InstantiateObject(GameObject thingToInstantiate, GameObject thingToInstantiate2)
    {
        displayManager.DisplayMessage("Made a thing!");
        Instantiate(thingToInstantiate, spawnPoint.position - Vector3.one, spawnPoint.rotation);
        Instantiate(thingToInstantiate2, spawnPoint.position + Vector3.one, spawnPoint.rotation);
    }
}
