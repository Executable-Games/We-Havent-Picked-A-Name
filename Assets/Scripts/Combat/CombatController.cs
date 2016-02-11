using UnityEngine;
using System.Collections;

/// <summary>
/// Controller for the Combat Scene to figure out whose turn it is, etc.
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/10/16
public class CombatController : MonoBehaviour {

    /// <summary>
    /// Number of seconds in a turn
    /// </summary>
    // NOTE(jordan): 5 seconds for turns will probably be something we want to adjust
    public int turnInterval = 5;

    /// <summary>
    /// Public flag for whether it is the player's turn
    /// </summary>
    public bool playerTurn = true;

    /// <summary>
    /// Ref to CombatUI child object
    /// </summary>
    private GameObject CombatUI;

    /// <summary>
    /// Ref to fancy shmancy CombatTimer
    /// </summary>
    // NOTE(jordan): every combat item needing a timer should refer to THIS timer.
    private Timer CombatTimer;

    /// <summary>
    /// Template strings for constructing a 'turn over!' message
    /// </summary>
    private string turnOverTemplate = "<b>Turn over!</b> It is now {0} turn.";
    private string playerTurnText   = "<color=#44cc44>your</color>";
    private string enemyTurnText    = "<color=#ff4444>enemy</color>";

    /// <summary>
    /// Construct a turn over message appropriate for the coming turn
    /// </summary>
    /// <returns>Turn over message with color information</returns>
    private string TurnOverMessage () {
        return string.Format(turnOverTemplate, playerTurn ? playerTurnText : enemyTurnText);
    }

    // Use this for initialization
    void Start () {
        // NOTE(jordan): CombatUI is the only child of this object, otherwise this doesn't necessarily work
        CombatUI    = transform.GetChild(0).gameObject;
        CombatTimer = GetComponent<Timer>();

        CombatUIController uiController = CombatUI.GetComponent<CombatUIController>();

        // NOTE(jordan): this is much nicer than hard-coding a timer every time you need one.
        CombatTimer.Every(turnInterval, delegate {
            // NOTE(jordan): switch turn
            playerTurn = !playerTurn;
            // NOTE(jordan): set ui message
            uiController.SetMessage(TurnOverMessage());
            // NOTE(jordan): show message for 3 seconds (needs to be less than turnInterval or it will show and hide at the same time ;) )
            uiController.Show(turnInterval / 2f);
        });
    }
}
