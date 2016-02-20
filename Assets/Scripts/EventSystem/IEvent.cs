using System.Collections.Generic;

namespace EventSystem {
    public interface IEvent {
        IEventListener Listener { get; }
    }

    public interface IEvent<ActionType> : IEvent {
        new IEventListener<ActionType> Listener { get; }
    }
}
