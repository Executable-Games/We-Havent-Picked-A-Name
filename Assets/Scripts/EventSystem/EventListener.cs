using System;
using System.Collections.Generic;

namespace EventSystem {
    public class EventListenerBase {
        protected Type _eventType;

        public Type EventType {
            get {
                return _eventType;
            }
        }
    }

    public class EventListener : EventListenerBase {
        private List<Action> _callbacks = new List<Action>();

        public List<Action> Callbacks {
            get {
                return _callbacks;
            }
        }

        public void Invoke () {
            Callbacks.ForEach((cb) => cb());
        }

        public EventListener (Type evType) {
            _eventType = evType;
        }
    }

    public class EventListener<P1> : EventListenerBase {
        private List<Action<P1>> _callbacks = new List<Action<P1>>();

        public List<Action<P1>> Callbacks {
            get {
                return _callbacks;
            }
        }

        public void Invoke<I> (I arg) where I : P1 {
            Callbacks.ForEach((cb) => cb(arg));
        }

        public EventListener (Type evType) {
            _eventType = evType;
        }
    }

    public class EventListener<P1, P2> : EventListenerBase {
        private List<Action<P1, P2>> _callbacks = new List<Action<P1, P2>>();

        public List<Action<P1, P2>> Callbacks {
            get {
                return _callbacks;
            }
        }

        public void Invoke<I1, I2> (I1 arg1, I2 arg2) where I1 : P1 where I2 : P2 {
            Callbacks.ForEach((cb) => cb(arg1, arg2));
        }

        public EventListener (Type evType) {
            _eventType = evType;
        }
    }
}
