﻿using System;
using System.Collections.Generic;

namespace EventSystem {
    public interface IEventListener {
        List<Action> Callbacks { get; }
        Type EventType { get; }
        void Invoke ();
    }

    public interface IEventListener<ActionType> : IEventListener {
        new List<ActionType> Callbacks { get; }
    }
}