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
        Timer Timer = GetComponentInParent<Timer>();

        Timer.After(0.25f, () => Debug.Log("Hello from Unit!"));
    }
}
