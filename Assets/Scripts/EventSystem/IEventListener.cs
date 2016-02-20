using System;
using System.Collections.Generic;

namespace EventSystem {
    public interface IEventListenerBase {
        Type EventType { get; }
    }

    public interface IEventListener : IEventListenerBase {
        List<Action> Callbacks { get; }
    }

    public interface IEventListener<P1> : IEventListenerBase {
        List<Action<P1>> Callbacks { get; }
    }

    public interface IEventListener<P1, P2> : IEventListenerBase {
        List<Action<P1, P2>> Callbacks { get; }
    }

    public static class IEventListenerExtensions {
        public static void Invoke (this IEventListener l) {
            l.Callbacks.ForEach((cb) => cb());
        }

        public static void Invoke<P1> (this IEventListener<P1> l, P1 arg) {
            l.Callbacks.ForEach((cb) => cb(arg));
        }

        public static void Invoke<P1, P2> (this IEventListener<P1, P2> l, P1 arg1, P2 arg2) {
            l.Callbacks.ForEach((cb) => cb(arg1, arg2));
        }
    }
}
