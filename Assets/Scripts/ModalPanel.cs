using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class EventButtonDetails
{
    public string buttonTitle;
    public Sprite buttonBackground;
    public UnityAction action;
}

public class ModalPanelDetails
{
    public string title;
    public string question;
    public Sprite iconImage;
    public Sprite panelBackground;
    public EventButtonDetails button1Details;
    public EventButtonDetails button2Details;
    public EventButtonDetails button3Details;
}

public class ModalPanel : MonoBehaviour {

    public Text question;
    public Image iconImage;
    public Button opt1Button;
    public Button opt2Button;
    public Button opt3Button;

    public Text opt1Text;
    public Text opt2Text;
    public Text opt3Text;

    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }


    // how to choose an option on the dialogue box
    // UnityAction - pointer to a function
    public void PlayerGenChoice(ModalPanelDetails details)
    {
        modalPanelObject.SetActive(true);

        this.iconImage.gameObject.SetActive(false);
        opt1Button.gameObject.SetActive(false);
        opt2Button.gameObject.SetActive(false);
        opt3Button.gameObject.SetActive(false);

        this.question.text = details.question;

        if (details.iconImage)
        {
            this.iconImage.sprite = details.iconImage;
            this.iconImage.gameObject.SetActive(true);
        }

        opt1Button.onClick.RemoveAllListeners();
        opt1Button.onClick.AddListener(details.button1Details.action);
        opt1Button.onClick.AddListener(ClosePanel);
        opt1Text.text = details.button1Details.buttonTitle;
        opt1Button.gameObject.SetActive(true);

        if (details.button2Details != null)
        {
            opt2Button.onClick.RemoveAllListeners();
            opt2Button.onClick.AddListener(details.button2Details.action);
            opt2Button.onClick.AddListener(ClosePanel);
            opt2Text.text = details.button2Details.buttonTitle;
            opt2Button.gameObject.SetActive(true);
        }

        if (details.button3Details != null)
        {
            opt3Button.onClick.RemoveAllListeners();
            opt3Button.onClick.AddListener(details.button3Details.action);
            opt3Button.onClick.AddListener(ClosePanel);
            opt3Text.text = details.button3Details.buttonTitle;
            opt3Button.gameObject.SetActive(true);
        }
    }
    

    public void PlayerChoice(string question, UnityAction opt3, Sprite iconImage = null)
    {
        modalPanelObject.SetActive(true);
        opt3Button.onClick.RemoveAllListeners();
        opt3Button.onClick.AddListener(opt3);
        opt3Button.onClick.AddListener(ClosePanel);

        this.question.text = question;
        if (iconImage)
            this.iconImage.sprite = iconImage;

        if (iconImage) 
            this.iconImage.gameObject.SetActive(true);
        else
            this.iconImage.gameObject.SetActive(false);

        opt1Button.gameObject.SetActive(false);
        opt2Button.gameObject.SetActive(false);
        opt3Button.gameObject.SetActive(true);

    }
    public void PlayerChoice(string question, UnityAction opt1, UnityAction opt2, UnityAction opt3)
    {
        modalPanelObject.SetActive(true);

        opt1Button.onClick.RemoveAllListeners();
        opt1Button.onClick.AddListener(opt1);
        opt1Button.onClick.AddListener(ClosePanel);

        opt2Button.onClick.RemoveAllListeners();
        opt2Button.onClick.AddListener(opt2);
        opt2Button.onClick.AddListener(ClosePanel);

        opt3Button.onClick.RemoveAllListeners();
        opt3Button.onClick.AddListener(opt3);
        opt3Button.onClick.AddListener(ClosePanel);

        this.question.text = question;

        this.iconImage.gameObject.SetActive(false);
        opt1Button.gameObject.SetActive(true);
        opt2Button.gameObject.SetActive(true);
        opt3Button.gameObject.SetActive(true);
    }


    // how to choose an option on the dialogue box (with an icon)
    public void PlayerChoice(string question, Sprite iconImage, UnityAction opt1, UnityAction opt2, UnityAction opt3)
    {
        modalPanelObject.SetActive(true);

        opt1Button.onClick.RemoveAllListeners();
        opt1Button.onClick.AddListener(opt1);
        opt1Button.onClick.AddListener(ClosePanel);

        opt2Button.onClick.RemoveAllListeners();
        opt2Button.onClick.AddListener(opt2);
        opt2Button.onClick.AddListener(ClosePanel);

        opt3Button.onClick.RemoveAllListeners();
        opt3Button.onClick.AddListener(opt3);
        opt3Button.onClick.AddListener(ClosePanel);

        this.question.text = question;
        this.iconImage.sprite = iconImage;

        this.iconImage.gameObject.SetActive(true);
        opt1Button.gameObject.SetActive(true);
        opt2Button.gameObject.SetActive(true);
        opt3Button.gameObject.SetActive(true);

    }

    public void PlayerChoice(string question, UnityAction opt1, UnityAction opt2)
    {
        modalPanelObject.SetActive(true);

        opt1Button.onClick.RemoveAllListeners();
        opt1Button.onClick.AddListener(opt1);
        opt1Button.onClick.AddListener(ClosePanel);

        opt2Button.onClick.RemoveAllListeners();
        opt2Button.onClick.AddListener(opt2);
        opt2Button.onClick.AddListener(ClosePanel);

        this.question.text = question;

        this.iconImage.gameObject.SetActive(false);
        opt1Button.gameObject.SetActive(true);
        opt2Button.gameObject.SetActive(true);
        opt3Button.gameObject.SetActive(false);


    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
