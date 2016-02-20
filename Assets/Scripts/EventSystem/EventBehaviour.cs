using UnityEngine;
using System.Collections.Generic;

namespace EventSystem {
    public abstract class EventBehaviour : MonoBehaviour {
        abstract public IEventListener Listener {
            get;
        }

        void Awake () {
            Debug.Log(string.Format("Register Event (Should only happen ONCE): {0}", this));
            EventManager.Listeners.Add(this.Listener);
            Debug.Log(string.Format("Event Listeners: {0}", EventManager.Listeners));
        }
    }

    public abstract class EventBehaviour<ActionType> : MonoBehaviour {
        abstract public IEventListener<ActionType> Listener {
            get;
        }

        void Awake () {
            Debug.Log(string.Format("Register Event (Should only happen ONCE): {0}", this));
            EventManager.Listeners.Add(this.Listener);
            Debug.Log(string.Format("Event Listeners: {0}", EventManager.Listeners));
        }
    }
}
