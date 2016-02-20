using UnityEngine;
using System;
using System.Collections.Generic;
using EventSystem;

namespace Combat.Events {
    public class UnitLives : EventBehaviour, IEvent {
        public static BasicListener<UnitLives> listener = new BasicListener<UnitLives>();

        override public IEventListener Listener {
            get {
                return listener;
            }
        }
    }
}
