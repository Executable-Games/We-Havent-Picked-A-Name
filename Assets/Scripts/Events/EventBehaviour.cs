using UnityEngine;
using System.Collections.Generic;

namespace Events {
    public abstract class EventBehaviour : MonoBehaviour {
        List<IEventListener> listeners;

        abstract public IEventListener Listener {
            get;
        }

        void Awake () {
            listeners = transform.root.GetComponent<EventSystem>().Listeners;
            Debug.Log("Register Event");
            listeners.Add(this.Listener);
            Debug.Log(string.Format("Event Listeners: {0}", listeners));
        }
    }
}
