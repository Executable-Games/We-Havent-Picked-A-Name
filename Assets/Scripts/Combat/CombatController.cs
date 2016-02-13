﻿using UnityEngine;
using System.Collections;
// NOTE(jordan): List
using System.Collections.Generic;
// NOTE(jordan): UnitsCollection
using UnitGroups;
// NOTE(jordan): List.All
using System.Linq;

/// <summary>
/// Controller for the Combat Scene to figure out whose turn it is, etc.
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/13/16 - Add allies/enemies
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
    /// Ref to CombatUIController
    /// </summary>
    private CombatUIController UIController;

    /// <summary>
    /// Ref to fancy shmancy CombatTimer
    /// </summary>
    // NOTE(jordan): every combat item needing a timer should refer to THIS timer.
    private Timer CombatTimer;

    /// <summary>
    /// The combat Stage object
    /// </summary>
    private GameObject Stage;

    /// <summary>
    /// Enumerables of ally and enemy units
    /// </summary>
    private UnitsCollection PlayerUnits;
    private UnitsCollection EnemyUnits;

    /// <summary>
    /// UnitGroupControllers for player and enemy units
    /// </summary>
    private UnitGroupController EnemyUnitGroupController;
    private UnitGroupController PlayerUnitGroupController;

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

    private void InitializeUnitGroups () {
        GameObject playerUnitsObj = Stage.transform.Find("Player Units").gameObject;
        GameObject enemyUnitsObj  = Stage.transform.Find("Enemy Units").gameObject;

        PlayerUnitGroupController = playerUnitsObj.GetComponent<UnitGroupController>();
        EnemyUnitGroupController  = enemyUnitsObj.GetComponent<UnitGroupController>();

        PlayerUnits = PlayerUnitGroupController.Units;
        EnemyUnits  = EnemyUnitGroupController.Units;
    }

    // Use this for initialization
    void Start () {
        Stage        = transform.Find("Stage").gameObject;
        CombatUI     = transform.Find("Combat UI").gameObject;
        CombatTimer  = GetComponent<Timer>();
        UIController = CombatUI.GetComponent<CombatUIController>();

        InitializeUnitGroups();

        CombatTimer.Every(turnInterval, OnTurn);
    }

    private void OnTurn () {
        // NOTE(jordan): Stop timer on Game Over
        if (GameOver()) {
            CombatTimer.Remove(turnInterval, OnTurn);
            return;
        }

        // NOTE(jordan): switch turn
        playerTurn = !playerTurn;
        // NOTE(jordan): set ui message
        UIController.SetMessage(TurnOverMessage());
        // NOTE(jordan): show message for 1/2 turnInterval seconds (needs to be less than turnInterval or it will show and hide at the same time ;) )
        UIController.Show(turnInterval / 2f);
    }

    private bool GameOver () {
        if (PlayerUnits.All((au) => au.isDead)) {
            EndScreen(false);
            return true;
        }

        if (EnemyUnits.All((eu) => eu.isDead)) {
            EndScreen(true);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Displays the end screen
    /// Different display based on victory of defeat (T/F)
    /// </summary>
    private void EndScreen(bool victory){
        //NOTE(aaron): not implemented yet
    }
}
