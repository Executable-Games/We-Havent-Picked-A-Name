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

        public void Invoke (P1 arg) {
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

        public void Invoke (P1 arg1, P2 arg2) {
            Callbacks.ForEach((cb) => cb(arg1, arg2));
        }

        public EventListener (Type evType) {
            _eventType = evType;
        }
    }

    public class EventListener<P1, P2, P3> : EventListenerBase {
        private List<Action<P1, P2, P3>> _callbacks = new List<Action<P1, P2, P3>>();

        public List<Action<P1, P2, P3>> Callbacks {
            get {
                return _callbacks;
            }
        }

        public void Invoke (P1 arg1, P2 arg2, P3 arg3) {
            Callbacks.ForEach((cb) => cb(arg1, arg2, arg3));
        }

        public EventListener (Type evType) {
            _eventType = evType;
        }
    }
}
