using UnityEngine;
using System.Collections.Generic;

namespace EventSystem {
    public abstract class EventBehaviour : MonoBehaviour {
        List<IEventListener> listeners;

        abstract public IEventListener Listener {
            get;
        }

        void Awake () {
            listeners = EventManager.Listeners;
            Debug.Log(string.Format("Register Event (Should only happen ONCE): {0}", this));
            listeners.Add(this.Listener);
            Debug.Log(string.Format("Event Listeners: {0}", listeners));
        }
    }
}
