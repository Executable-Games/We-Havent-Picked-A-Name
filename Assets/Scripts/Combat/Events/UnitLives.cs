using UnityEngine;
using System;
using System.Collections.Generic;
using EventSystem;

namespace Combat.Events {
    public class UnitLives : EventBehaviour<Unit>, IEvent<Unit> {
        public class _listener<T> : IEventListener<Unit> where T: IEvent<Unit> {
            private List<Action<Unit>> _callbacks;
            private Type _eventType;

            List<Action> IEventListener.Callbacks {
                get {
                    return new List<Action>();
                }
            }

            public List<Action<Unit>> Callbacks {
                get {
                    return _callbacks;
                }
            }

            public Type EventType {
                get {
                    return _eventType;
                }
            }

            public void Invoke () {
              // NOTE(jordan): this makes no sense to use
            }

            public void Invoke (Unit u) {
                _callbacks.ForEach((cb) => cb(u));
            }

            public _listener () {
                _eventType = typeof(T);
                _callbacks = new List<Action<Unit>>();
            }
        }

        public static _listener<UnitLives> listener = new _listener<UnitLives>();

        override public IEventListener<Unit> Listener {
            get {
                return listener;
            }
        }

        IEventListener IEvent.Listener {
            get {
                return listener;
            }
        }
    }
}
