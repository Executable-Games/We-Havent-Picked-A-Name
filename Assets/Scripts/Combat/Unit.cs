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

    void Start () {
        GameObject parent = transform.parent.gameObject;
        UnitGroupController parentController = parent.GetComponent<UnitGroupController>();
        Timer Timer = parentController.Timer;

        Timer.After(5, () => Debug.Log("Hello from Unit!"));
    }
}
