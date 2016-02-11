using UnityEngine;
using System.Collections;

/// <summary>
/// Unit Group Controller for handling groups of units
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/11/16
public class UnitGroupController : MonoBehaviour {

    private Timer Timer;

    // Use this for initialization
    void Start () {
        Timer = GetComponentInParent<Timer>();
    }
}
