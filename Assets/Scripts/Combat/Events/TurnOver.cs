using UnityEngine;
using System;
using System.Collections.Generic;
using EventSystem;

namespace Combat.Events {
    public class TurnOver : EventBehaviour, IEvent {
        public static BasicListener<TurnOver> listener = new BasicListener<TurnOver>();

        override public IEventListener Listener {
            get {
                return listener;
            }
        }
    }
}
