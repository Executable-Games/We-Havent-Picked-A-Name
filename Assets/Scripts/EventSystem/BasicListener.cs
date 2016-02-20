using System;
using System.Collections.Generic;

namespace EventSystem {
    public class BasicListener<T> : IEventListener where T: IEvent {
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
