using UnityEngine;
using System.Collections;
using GameEvents;

namespace Combat {
    using Events;
    public class UIInputController : MonoBehaviour {
        // Update is called once per frame
        void Update () {
            if (Controller.playerTurn) {
                if (Input.GetKeyUp("w") || Input.GetKeyUp("up") || Input.GetKeyUp("a") || Input.GetKeyUp("left")) {
                    Debug.Log("Got input cyclenext");
                    EventSystem.Trigger<CycleNextTarget>();
                }
                if (Input.GetKeyUp("s") || Input.GetKeyUp("down") || Input.GetKeyUp("d") || Input.GetKeyUp("right")) {
                    Debug.Log("Got input cycleprev");
                    EventSystem.Trigger<CyclePrevTarget>();
                }
                if (Input.GetKeyUp("space")) {
                    Debug.Log("Got input space");
                    EventSystem.Trigger<CommitSelection>();
                }
            }
        }
    }
}
