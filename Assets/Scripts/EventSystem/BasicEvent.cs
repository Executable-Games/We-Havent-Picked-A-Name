using System;
using System.Collections.Generic;

namespace EventSystem {
    public class BasicEvent<E> : EventBehaviour where E : EventBehaviour {
        public static BasicListener<E> listener = new BasicListener<E>();

        override public IEventListenerBase Listener {
            get {
                return listener;
            }
        }
    }

    public class BasicEvent<E, P> : EventBehaviour where E : EventBehaviour {
        public static BasicListener<E, P> listener = new BasicListener<E, P>();

        override public IEventListenerBase Listener {
            get {
                return listener;
            }
        }
    }

    public class BasicEvent<E, P1, P2> : EventBehaviour where E : EventBehaviour {
        public static BasicListener<E, P1, P2> listener = new BasicListener<E, P1, P2>();

        override public IEventListenerBase Listener {
            get {
                return listener;
            }
        }
    }
}
