using UnityEngine;
using System;
using System.Collections.Generic;

namespace EventSystem {
    public abstract class EventBehaviour : MonoBehaviour {
        abstract public IEventListenerBase Listener {
            get;
        }

        void Awake () {
            EventManager.Listeners.Add(this.Listener);
        }
    }
}
