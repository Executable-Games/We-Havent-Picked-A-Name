using UnityEngine;
using System;
using System.Collections.Generic;

namespace Events {
    public class EventSystem : MonoBehaviour {
        public List<IEventListener> Listeners = new List<IEventListener>();

        private IEventListener GetListenerFor<T> () where T: IEvent {
            Type eventType = typeof(T);
            return Listeners.Find((listener) => listener.EventType == eventType);
        }

        public void On<T> (Action callback) where T: IEvent {
            IEventListener l = GetListenerFor<T>();
            l.Callbacks.Add(callback);
        }

        public bool Off<T> (Action callback) where T: IEvent {
            IEventListener l = GetListenerFor<T>();
            return l.Callbacks.Remove(callback);
        }

        public void Trigger<T> () where T: IEvent {
            IEventListener l = GetListenerFor<T>();
            l.Invoke();
        }
    }
}
