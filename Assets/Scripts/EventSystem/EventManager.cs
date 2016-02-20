using System;
using System.Collections.Generic;

namespace EventSystem {
    public static class EventManager {
        public static List<IEventListenerBase> Listeners = new List<IEventListenerBase>();

        private static IEventListener GetListenerFor<E> () where E : EventBehaviour {
            Type eventType = typeof(E);
            return Listeners.Find((listener) => listener.EventType == eventType) as IEventListener;
        }

        private static IEventListener<P> GetListenerFor<E, P> () where E : EventBehaviour {
            List<IEventListener<P>> listeners;
            listeners = Listeners.FindAll((listener) => listener is IEventListener<P>)
                                 .ConvertAll<IEventListener<P>>((listener) => listener as IEventListener<P>);
            return listeners.Find((listener) => listener.Callbacks is List<Action<P>>);
        }

        private static IEventListener<P1, P2> GetListenerFor<E, P1, P2> () where E : EventBehaviour {
            List<IEventListener<P1, P2>> listeners;
            listeners = Listeners.FindAll((listener) => listener is IEventListener<P1, P2>)
                                 .ConvertAll<IEventListener<P1, P2>>((listener) => listener as IEventListener<P1, P2>);
            return listeners.Find((listener) => listener.Callbacks is List<Action<P1, P2>>);
        }

        public static void On<E> (Action callback) where E : EventBehaviour {
            IEventListener l = GetListenerFor<E>();
            l.Callbacks.Add(callback);
        }

        public static void On<E, P> (Action<P> callback) where E : EventBehaviour {
            IEventListener<P> l = GetListenerFor<E, P>();
            l.Callbacks.Add(callback);
        }

        public static void On<E, P1, P2> (Action<P1, P2> callback) where E : EventBehaviour {
            IEventListener<P1, P2> l = GetListenerFor<E, P1, P2>();
            l.Callbacks.Add(callback);
        }

        public static bool Off<E> (Action callback) where E : EventBehaviour {
            IEventListener l = GetListenerFor<E>();
            return l.Callbacks.Remove(callback);
        }

        public static bool Off<E, P> (Action<P> callback) where E : EventBehaviour {
            IEventListener<P> l = GetListenerFor<E, P>();
            return l.Callbacks.Remove(callback);
       }

        public static bool Off<E, P1, P2> (Action<P1, P2> callback) where E : EventBehaviour {
            IEventListener<P1, P2> l = GetListenerFor<E, P1, P2>();
            return l.Callbacks.Remove(callback);
       }

        public static void Trigger<E> () where E : EventBehaviour {
            IEventListener l = GetListenerFor<E>();
            l.Invoke();
        }

        public static void Trigger<E, P> (P arg) where E : EventBehaviour {
            IEventListener<P> l = GetListenerFor<E, P>();
            l.Invoke<P>(arg);
        }

        public static void Trigger<E, P1, P2> (P1 arg1, P2 arg2) where E : EventBehaviour {
            IEventListener<P1, P2> l = GetListenerFor<E, P1, P2>();
            l.Invoke<P1, P2>(arg1, arg2);
        }
    }
}
