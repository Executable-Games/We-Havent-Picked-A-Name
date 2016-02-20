using UnityEngine;
using System;
using System.Collections.Generic;
using EventSystem;

namespace Combat.Events {
    public class UnitDie : EventBehaviour, IEvent {
        public static BasicListener<UnitDie> listener = new BasicListener<UnitDie>();

        override public IEventListener Listener {
            get {
                return listener;
            }
        }
    }
}
