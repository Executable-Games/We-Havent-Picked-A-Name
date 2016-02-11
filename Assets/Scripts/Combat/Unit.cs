using UnityEngine;
using System.Collections;

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
