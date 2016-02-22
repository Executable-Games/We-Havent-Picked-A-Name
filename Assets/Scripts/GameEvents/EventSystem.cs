using System;
using System.Collections.Generic;

namespace GameEvents {
    /// <summary>
    /// Global EventSystem
    /// </summary>
    public static class EventSystem {
        /// <summary>
        /// Map of Events by Type
        /// </summary>
        public static Dictionary<Type, GameEventBase> Events = new Dictionary<Type, GameEventBase>();

        /// <summary>
        /// Utility method for getting an event listener from the Events dictionary
        /// </summary>
        /// <typeparam name="E">Event type to look up</typeparam>
        /// <returns>EventListener for Event of type E</returns>
        private static EventListenerBase GetListenerFor<E> () where E : GameEventBase {
            GameEventBase ge;
            try {
                Events.TryGetValue(typeof(E), out ge);
                return ge.Listener;
            } catch (KeyNotFoundException) {
                UnityEngine.Debug.LogError(string.Format("Could not find event {0}, are you sure it is in the scene?", typeof(E)));
                return null;
            }
        }

        /// <summary>
        /// Method for attaching a callback to an Event
        /// </summary>
        /// <typeparam name="E">Event type to attach a callback to</typeparam>
        /// <param name="callback">Callback to attach</param>
        public static void On<E> (Action callback) where E : GameEvent {
            (GetListenerFor<E>() as EventListener).Callbacks.Add(callback);
        }

        /// <see cref="On(Action)"/>
        public static void On<E, P> (Action<P> callback) where E : GameEvent<P> {
            (GetListenerFor<E>() as EventListener<P>).Callbacks.Add(callback);
        }

        /// <see cref="On(Action)"/>
        public static void On<E, P1, P2> (Action<P1, P2> callback) where E : GameEvent<P1, P2> {
            (GetListenerFor<E>() as EventListener<P1, P2>).Callbacks.Add(callback);
        }

        /// <see cref="On(Action)"/>
        public static void On<E, P1, P2, P3> (Action<P1, P2, P3> callback) where E : GameEvent<P1, P2, P3> {
            (GetListenerFor<E>() as EventListener<P1, P2, P3>).Callbacks.Add(callback);
        }

        /// <summary>
        /// Method for detaching a callback from an Event
        /// </summary>
        /// <typeparam name="E">Event type to detach a callback from</typeparam>
        /// <param name="callback">Callback to detach</param>
        /// <returns></returns>
        public static bool Off<E> (Action callback) where E : GameEvent {
            return (GetListenerFor<E>() as EventListener).Callbacks.Remove(callback);
        }

        /// <see cref="Off(Action)"/>
        public static bool Off<E, P> (Action<P> callback) where E : GameEvent<P> {
            return (GetListenerFor<E>() as EventListener<P>).Callbacks.Remove(callback);
       }

        /// <see cref="Off(Action)"/>
        public static bool Off<E, P1, P2> (Action<P1, P2> callback) where E : GameEvent<P1, P2> {
            return (GetListenerFor<E>() as EventListener<P1, P2>).Callbacks.Remove(callback);
       }

        /// <see cref="Off(Action)"/>
        public static void Off<E, P1, P2, P3> (Action<P1, P2, P3> callback) where E : GameEvent<P1, P2, P3> {
            (GetListenerFor<E>() as EventListener<P1, P2, P3>).Callbacks.Remove(callback);
        }

        /// <summary>
        /// Method for triggering an Event's callbacks
        /// </summary>
        /// <typeparam name="E">Event type to trigger</typeparam>
        public static void Trigger<E> () where E : GameEvent {
            (GetListenerFor<E>() as EventListener).Invoke();
        }

        /// <see cref="Trigger()"/>
        public static void Trigger<E, P> (P arg) where E : GameEvent<P> {
            (GetListenerFor<E>() as EventListener<P>).Invoke(arg);
        }

        /// <see cref="Trigger()"/>
        public static void Trigger<E, P1, P2> (P1 arg1, P2 arg2) where E : GameEvent<P1, P2> {
            (GetListenerFor<E>() as EventListener<P1, P2>).Invoke(arg1, arg2);
        }

        /// <see cref="Trigger()"/>
        public static void Trigger<E, P1, P2, P3> (P1 arg1, P2 arg2, P3 arg3) where E : GameEvent<P1, P2, P3> {
            (GetListenerFor<E>() as EventListener<P1, P2, P3>).Invoke(arg1, arg2, arg3);
        }
    }
}
