﻿using System;
using System.Collections.Generic;

namespace GameEvents {
    /// <summary>
    /// Base class for GameEvents, which are Behaviours that can be placed in Unity
    /// </summary>
    public abstract class GameEventBase : UnityEngine.MonoBehaviour {
        /// <summary>
        /// Property accessor for Event's listener
        /// </summary>
        abstract public EventListenerBase Listener { get; }

        /// <summary>
        /// Abstract method for instantiating different listener types
        /// </summary>
        /// <param name="t"></param>
        abstract protected void InstantiateListener (Type t);

        void Awake () {
            Type t = GetType();
            InstantiateListener(t);
            //// !DEBUG(jordan)
            //UnityEngine.Debug.Log(string.Format("Registering Event. {0} {1} {2}", this, Listener, EventSystem.Events));
            EventSystem.Events.Add(t, this);
        }
    }

    /// <summary>
    /// GameEvent with paremeterless callbacks
    /// </summary>
    public class GameEvent : GameEventBase {
        public EventListener listener;

        override public EventListenerBase Listener {
            get {
                return listener;
            }
        }

        override protected void InstantiateListener (Type t) {
            listener = new EventListener(t);
        }
    }

    /// <summary>
    /// GameEvent with one parameter callbacks
    /// </summary>
    /// <typeparam name="P">First callback param type</typeparam>
    public class GameEvent<P> : GameEventBase {
        public EventListener<P> listener;

        override public EventListenerBase Listener {
            get {
                return listener;
            }
        }

        override protected void InstantiateListener (Type t) {
            listener = new EventListener<P>(t);
        }
    }

    /// <summary>
    /// GameEvent with two parameter callbacks
    /// </summary>
    /// <typeparam name="P1">First callback param type</typeparam>
    /// <typeparam name="P2">Second callback param type</typeparam>
    public class GameEvent<P1, P2> : GameEventBase {
        public EventListener<P1, P2> listener;

        override public EventListenerBase Listener {
            get {
                return listener;
            }
        }

        override protected void InstantiateListener (Type t) {
            listener = new EventListener<P1, P2>(t);
        }
    }

    /// <summary>
    /// GameEvent with three parameter callbacks
    /// </summary>
    /// <typeparam name="P1">First callback param type</typeparam>
    /// <typeparam name="P2">Second callback param type</typeparam>
    /// <typeparam name="P3">Third callback param type</typeparam>
    public class GameEvent<P1, P2, P3> : GameEventBase {
        public EventListener<P1, P2, P3> listener;

        override public EventListenerBase Listener {
            get {
                return listener;
            }
        }

        override protected void InstantiateListener (Type t) {
            listener = new EventListener<P1, P2, P3>(t);
        }
    }
}
