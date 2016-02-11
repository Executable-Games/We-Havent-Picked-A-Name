using UnityEngine;
using System.Collections;

public class UnitGroupController : MonoBehaviour {

    public Timer Timer;

    // Use this for initialization
    void Start () {
        Timer = GetComponentInParent<Timer>();
    }
}
