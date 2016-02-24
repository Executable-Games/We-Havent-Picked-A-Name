using UnityEngine;
using System.Collections;
using System.Linq;

using GameEvents;
using Attach;

namespace Combat.Targeting {
    using Events;

    /// <summary>
    /// Public Reticle State manipulator
    /// </summary>
    public struct ReticleState {
        private Reticle Reticle;
        private SpriteRenderer Renderer;

        /// <summary>
        /// Property for changing attach point
        /// </summary>
        public AttachPoint AttachPoint {
            get {
                return Reticle.attachPoint;
            }
            set {
                Reticle.attachPoint = value;
            }
        }

        /// <summary>
        /// Property for flipping sprite
        /// </summary>
        public bool FlipX {
            get {
                return Renderer.flipX;
            }

            set {
                Renderer.flipX = value;
            }
        }

        public ReticleState (Reticle r) {
            Reticle = r;
            Renderer = Reticle.GetComponent<SpriteRenderer>();
            AttachPoint = AttachPoint.TopCenter;
        }
    }

    /// <summary>
    /// Reticle for combat target selection
    /// </summary>
    /// Author: Jordan (GitHub: @skorlir)
    /// Modified 2/23/16: extracted out TargetingSystem to separate logic from presentation
    /// 2/22/16
    public class Reticle : Attachs {
        /// <summary>
        /// Current reticle UI state
        /// </summary>
        public ReticleState State;

        /// <summary>
        /// Unit currently pointed to
        /// </summary>
        public Unit SelectedUnit;

        /// <summary>
        /// Convenience method for attaching to a unit
        /// </summary>
        /// <param name="u"></param>
        public void Attach (Unit u) {
            SelectedUnit = u;
            attachTarget = u.gameObject;
            AttachToTarget();
        }

        void Start () {
            State = new ReticleState(this);
            // NOTE(jordan): enable only on player's turn
            EventSystem.On<TurnOver>(() => gameObject.SetActive(Controller.playerTurn));
        }
    }
}