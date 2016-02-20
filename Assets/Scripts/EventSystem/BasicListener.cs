using System;
using System.Collections.Generic;

namespace EventSystem {
    public class BasicListener<E> : IEventListener where E: EventBehaviour {
        private List<Action> _callbacks;
        private Type _eventType;

        public List<Action> Callbacks {
            get {
                return _callbacks;
            }
        }

        public Type EventType {
            get {
                return _eventType;
            }
        }

        public BasicListener () {
            _eventType = typeof(E);
            _callbacks = new List<Action>();
        }
    }

    public class BasicListener<E, P> : IEventListener<P> where E: EventBehaviour {
        private List<Action<P>> _callbacks;
        private Type _eventType;

        public List<Action<P>> Callbacks {
            get {
                return _callbacks;
            }
        }

        public Type EventType {
            get {
                return _eventType;
            }
        }

        public BasicListener () {
            _eventType = typeof(E);
            _callbacks = new List<Action<P>>();
        }
    }

    public class BasicListener<E, P1, P2> : IEventListener<P1, P2> where E: EventBehaviour {
        private List<Action<P1, P2>> _callbacks;
        private Type _eventType;

        public List<Action<P1, P2>> Callbacks {
            get {
                return _callbacks;
            }
        }

        public Type EventType {
            get {
                return _eventType;
            }
        }

        public BasicListener () {
            _eventType = typeof(E);
            _callbacks = new List<Action<P1, P2>>();
        }
    }
}
