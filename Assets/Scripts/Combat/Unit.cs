using UnityEngine;
using System.Collections;

/// <summary>
/// Unit script for managing combat units
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/11/16
public class Unit : MonoBehaviour {

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
		Health = GetComponent<CombatHealth> ();

		// !DEBUG(aaron)
        //Timer Timer = GetComponentInParent<Timer>();
        //Timer.After(0.25f, () => Debug.Log("Hello from Unit!"));
    }





}
