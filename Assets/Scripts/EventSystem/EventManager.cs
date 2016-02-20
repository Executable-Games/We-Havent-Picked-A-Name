using UnityEngine;
using System;
using System.Collections.Generic;

namespace EventSystem {
    public static class EventManager {
        public static List<IEventListener> Listeners = new List<IEventListener>();

        private static IEventListener GetListenerFor<T> () where T: IEvent {
            Type eventType = typeof(T);
            return Listeners.Find((listener) => listener.EventType == eventType);
        }

        public static void On<T> (Action callback) where T: IEvent {
            IEventListener l = GetListenerFor<T>();
            l.Callbacks.Add(callback);
        }

        public static void On<T, U> (Action<U> callback) where T : IEvent {
            IEventListener<U> l = (GetListenerFor<T>() as IEventListener<U>);
            l.Callbacks.Add(callback);
        }

        public static bool Off<T> (Action callback) where T: IEvent {
            IEventListener l = GetListenerFor<T>();
            return l.Callbacks.Remove(callback);
        }

        public static bool Off<T, U> (Action<U> callback) where T : IEvent {
            IEventListener<U> l = (GetListenerFor<T>() as IEventListener<U>);
            return l.Callbacks.Remove(callback);
       }

        public static void Trigger<T> () where T: IEvent {
            IEventListener l = GetListenerFor<T>();
            l.Invoke();
        }

        public static void Trigger<T, U> (U arg) where T : IEvent {
            IEventListener<U> l = (GetListenerFor<T>() as IEventListener<U>);
            l.Invoke(arg);
        }
    }
}
