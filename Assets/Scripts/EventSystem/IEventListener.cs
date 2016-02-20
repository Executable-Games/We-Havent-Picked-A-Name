using System;
using System.Collections.Generic;

namespace EventSystem {
    public interface IEventListener {
        List<Action> Callbacks { get; }
        Type EventType { get; }
        void Invoke ();
    }

    public interface IEventListener<ActionType> : IEventListener {
        new List<Action<ActionType>> Callbacks { get; }
        void Invoke (ActionType at);
    }
}
