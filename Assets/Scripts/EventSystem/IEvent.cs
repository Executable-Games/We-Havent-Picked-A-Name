using System.Collections.Generic;

namespace EventSystem {
    public interface IEvent {
        IEventListener Listener { get; }
    }

    public interface IEvent<ActionType> : IEvent {
        IEventListener<ActionType> Listener { get; }
    }
}
