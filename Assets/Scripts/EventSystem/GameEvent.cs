using UnityEngine;
using System;
using System.Collections.Generic;

namespace EventSystem {
    public abstract class GameEventBase : MonoBehaviour {
        abstract public EventListenerBase Listener { get; }

        abstract protected void InstantiateListener (Type t);

        void Awake () {
            Type t = GetType();
            InstantiateListener(t);
            EventManager.Events.Add(t, this);
            //// !DEBUG(jordan)
            //Debug.Log(string.Format("Registering Event. {0} {1} {2}", this, Listener, EventManager.Events));
        }
    }

    public class GameEvent : GameEventBase {
        public static EventListener listener;

        override public EventListenerBase Listener {
            get {
                return listener;
            }
        }

        override protected void InstantiateListener (Type t) {
            listener = new EventListener(t);
        }
    }

    public class GameEvent<P> : GameEventBase {
        public static EventListener<P> listener;

        override public EventListenerBase Listener {
            get {
                return listener;
            }
        }

        override protected void InstantiateListener (Type t) {
            listener = new EventListener<P>(t);
        }
    }

    public class GameEvent<P1, P2> : GameEventBase {
        public static EventListener<P1, P2> listener;

        override public EventListenerBase Listener {
            get {
                return listener;
            }
        }

        override protected void InstantiateListener (Type t) {
            listener = new EventListener<P1, P2>(t);
        }
    }
}
