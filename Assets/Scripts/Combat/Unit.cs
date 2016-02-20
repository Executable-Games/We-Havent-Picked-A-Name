using UnityEngine;
using System.Collections;
using EventSystem;
using Combat.Events;

/// <summary>
/// Unit script for managing combat units
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/13/16 - add public Health
/// 2/11/16
public class Unit : MonoBehaviour {
    /// <summary>
    /// Reference to CombatController
    /// </summary>
    private CombatController Controller;

    /// <summary>
    /// Public player|enemy flag
    /// </summary>
    public bool isEnemy = true;

    /// <summary>
    /// Reference to combat health
    /// </summary>
    public CombatHealth Health;

    /// <summary>
    /// Determines if the Unit is dead or not
    /// </summary>
    /// <returns>True if health is 0; otherwise, return False</returns>
    public bool isDead {
        get {
            return this.Health.hp == 0;
        }
    }

    void Start () {
        Controller = transform.root.gameObject.GetComponent<CombatController>();
        Health = GetComponent<CombatHealth>();

        EventManager.Trigger<UnitLives, Unit>(this);

        // !DEBUG(aaron)
        //Controller.CombatTimer.After(0.25f, () => Debug.Log("Hello from Unit!"));
    }
}