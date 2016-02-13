using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	/// Lists of allie and enemy units
	/// </summary>
	private List<Unit> allies;
	private List<Unit> enemies;

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

		//Get children sorted into lists
		allies = new List<Unit>();
		enemies = new List<Unit>();
		foreach (Unit tempUnit in GetComponentsInChildren<Unit>()) {
			if (tempUnit.isEnemy)
				enemies.Add (tempUnit);
			else
				allies.Add (tempUnit);
		}

        CombatUIController uiController = CombatUI.GetComponent<CombatUIController>();

        // NOTE(jordan): this is much nicer than hard-coding a timer every time you need one.
        CombatTimer.Every(turnInterval, delegate {
			//NOTE(aaron): check if all dead
			bool allDead = true;
			foreach (Unit tempUnit in allies)
				if (!tempUnit.isDead)
					allDead = false;
			if (allDead)
				endScreen(false);
			allDead = true;
			foreach (Unit tempUnit in enemies)
				if (!tempUnit.isDead)
					allDead = false;
			if (allDead)
				endScreen(true);

            // NOTE(jordan): switch turn
            playerTurn = !playerTurn;
            // NOTE(jordan): set ui message
            uiController.SetMessage(TurnOverMessage());
            // NOTE(jordan): show message for 1/2 turnInterval seconds (needs to be less than turnInterval or it will show and hide at the same time ;) )
            uiController.Show(turnInterval / 2f);
        });
    }

	/// <summary>
	/// Displays the end screen
	/// Different display based on victory of defeat (T/F)
	/// </summary>
	private void endScreen(bool victory){
		//NOTE(aaron): not implemented yet
	}
}
