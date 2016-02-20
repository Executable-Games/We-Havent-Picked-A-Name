using System;
using System.Collections.Generic;

namespace Events {
    public class BasicListener<T> : IEventListener {
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

        public void Invoke () {
            _callbacks.ForEach((cb) => cb());
        }

        public BasicListener () {
            _eventType = typeof(T);
            _callbacks = new List<Action>();
        }
    }
}
