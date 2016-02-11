using UnityEngine;
// NOTE(jordan): gives access to UI.Text
using UnityEngine.UI;
using System.Collections;
// NOTE(jordan): Generic namespace contains List
using System.Collections.Generic;

/// <summary>
/// Controller for Combat UI that can be used to show a message
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/10/16
public class CombatUIController : MonoBehaviour {
    /// <summary>
    /// UIText object to show/hide/change
    /// </summary>
    private Text UIText;

    /// <summary>
    /// UIText Container
    /// </summary>
    private GameObject UITextContainer;

    /// <summary>
    /// UI Message Panel
    /// </summary>
    private GameObject UIMessagePanel;

    /// <summary>
    /// Ref to CombatController CombatTimer component
    /// </summary>
    private Timer CombatTimer;

    void Start () {
        // NOTE(jordan): since CombatUI is a child of CombatController this works
        CombatTimer = GetComponentInParent<Timer>();
        // NOTE(jordan): this only works because CombatUI only has 1 child, and it's a UI.Text object
        UIMessagePanel  = gameObject.transform.GetChild(0).gameObject;
        UITextContainer = UIMessagePanel.transform.GetChild(0).gameObject;
        UIText          = UITextContainer.GetComponent<Text>();
    }

    /// <summary>
    /// Sets the message text for UIText
    /// </summary>
    /// <param name="newMessage">string to use for new message</param>
    public void SetMessage (string newMessage) {
        // !DEBUG(jordan)
        //Debug.Log(string.Format("SetMessage to {0}", newMessage));
        UIText.text = newMessage;
    }

    /// <summary>
    /// Show UIText
    /// </summary>
    public void Show () {
        // !DEBUG(jordan)
        //Debug.Log(string.Format("Show! message w/ text: {0}", UIText.text));
        UITextContainer.SetActive(true);
    }

    /// <summary>
    /// Show UIText for a certain duration
    /// </summary>
    /// <param name="duration">Amount of time to wait before hiding</param>
    public void Show (float duration) {
        Show();
        CombatTimer.After(duration, delegate {
            // !DEBUG(jordan)
            //Debug.Log("Okay, now hide!");
            UITextContainer.SetActive(false);
        });
    }

    /// <summary>
    /// Show UIText for a certain number of seconds
    /// </summary>
    /// <see cref="Show(float)"/>
    public void Show (int seconds) {
        float duration = (float) seconds;

        Show(duration);
    }

    /// <summary>
    /// Hide UIText
    /// </summary>
    public void Hide () {
        UITextContainer.SetActive(false);
    }

}
