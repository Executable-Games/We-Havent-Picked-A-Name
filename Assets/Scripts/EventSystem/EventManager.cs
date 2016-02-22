using System;
using System.Collections.Generic;

namespace EventSystem {
    public static class EventManager {
        public static Dictionary<Type, GameEventBase> Events = new Dictionary<Type, GameEventBase>();

        private static EventListenerBase GetListenerFor<E> () where E : GameEventBase {
            GameEventBase ge = Events[typeof(E)];
            return ge.Listener;
        }

        public static void On<E> (Action callback) where E : GameEvent {
            (GetListenerFor<E>() as EventListener).Callbacks.Add(callback);
        }

        public static void On<E, P> (Action<P> callback) where E : GameEvent<P> {
            (GetListenerFor<E>() as EventListener<P>).Callbacks.Add(callback);
        }

        public static void On<E, P1, P2> (Action<P1, P2> callback) where E : GameEvent<P1, P2> {
            (GetListenerFor<E>() as EventListener<P1, P2>).Callbacks.Add(callback);
        }

        public static void On<E, P1, P2, P3> (Action<P1, P2, P3> callback) where E : GameEvent<P1, P2, P3> {
            (GetListenerFor<E>() as EventListener<P1, P2, P3>).Callbacks.Add(callback);
        }

        public static bool Off<E> (Action callback) where E : GameEvent {
            return (GetListenerFor<E>() as EventListener).Callbacks.Remove(callback);
        }

        public static bool Off<E, P> (Action<P> callback) where E : GameEvent<P> {
            return (GetListenerFor<E>() as EventListener<P>).Callbacks.Remove(callback);
       }

        public static bool Off<E, P1, P2> (Action<P1, P2> callback) where E : GameEvent<P1, P2> {
            return (GetListenerFor<E>() as EventListener<P1, P2>).Callbacks.Remove(callback);
       }

        public static void Off<E, P1, P2, P3> (Action<P1, P2, P3> callback) where E : GameEvent<P1, P2, P3> {
            (GetListenerFor<E>() as EventListener<P1, P2, P3>).Callbacks.Remove(callback);
        }

        public static void Trigger<E> () where E : GameEvent {
            (GetListenerFor<E>() as EventListener).Invoke();
        }

        public static void Trigger<E, P> (P arg) where E : GameEvent<P> {
            (GetListenerFor<E>() as EventListener<P>).Invoke(arg);
        }

        public static void Trigger<E, P1, P2> (P1 arg1, P2 arg2) where E : GameEvent<P1, P2> {
            (GetListenerFor<E>() as EventListener<P1, P2>).Invoke(arg1, arg2);
        }

        public static void Trigger<E, P1, P2, P3> (P1 arg1, P2 arg2, P3 arg3) where E : GameEvent<P1, P2, P3> {
            (GetListenerFor<E>() as EventListener<P1, P2, P3>).Invoke(arg1, arg2, arg3);
        }
    }
}
