using UnityEngine;
using System.Collections;

using Attach;
using GameEvents;

namespace Combat.Targeting {
    using UnitGroups;
    using Events;

    /// <summary>
    /// Enum of possible targeting states
    /// </summary>
    public enum TargetingState {
        Selecting, Targeting
    }

    /// <summary>
    /// Targeting system for combat
    /// </summary>
    public class TargetingSystem : MonoBehaviour {
        /// <summary>
        /// Targeting reticle
        /// </summary>
        private Reticle Reticle;

        /// <summary>
        /// Current targeting state (see property accessor below)
        /// </summary>
        private TargetingState currently;

        /// <summary>
        /// Targeting related unit groups
        /// </summary>
        private UnitsCollection MoveablePlayerUnits;
        private UnitsCollection AllowedTargets;
        private UnitsEnumerator TargetsEnumerator;

        /// <summary>
        /// Target and Targeter
        /// </summary>
        private Unit Target;
        private Unit Targeter;

        /// <summary>
        /// Property accessor for current targeting state
        /// </summary>
        public TargetingState Currently {
            get {
                return currently;
            }
            set {
                currently = value;
                UpdateState();
            }
        }

        /// <summary>
        /// Update the state to look correct depending on targeting/selecting
        /// </summary>
        private void UpdateState () {
            bool targeting = Currently == TargetingState.Targeting;
            Reticle.State.FlipX = targeting;
            if (targeting) {
                Reticle.State.AttachPoint = AttachPoint.TopLeft;
                SetState(Controller.EnemyUnits, Target);
            } else {
                Reticle.State.AttachPoint = AttachPoint.TopRight;
                SetState(MoveablePlayerUnits, Targeter);
            }
        }

        /// <summary>
        /// Called when targeter selected
        /// </summary>
        private void TargeterSelected () {
            Targeter = Reticle.SelectedUnit;
            Currently = TargetingState.Targeting;
        }

        /// <summary>
        /// Called on target acquired
        /// </summary>
        private void TargetAcquired () {
            Target = Reticle.SelectedUnit;
            EventSystem.Trigger<TargetAcquired, Unit, Unit>(Targeter, Target);
            MoveablePlayerUnits.Remove(Targeter);

            if (MoveablePlayerUnits.Count == 0) {
                EventSystem.Trigger<TurnOver>();
            } else {
                Currently = TargetingState.Selecting;
            }
        }

        /// <summary>
        /// Initialize reticle and targeting state to default
        /// </summary>
        private void Reinitialize () {
            if (Controller.playerTurn) {
                MoveablePlayerUnits = new UnitsCollection(Controller.PlayerUnits.Living());
                Currently = TargetingState.Selecting;
            }
        }

        /// <summary>
        /// Set current state
        /// </summary>
        /// <param name="targets">Allowed targers</param>
        /// <param name="current">Initally selecte unit</param>
        private void SetState (UnitsCollection targets, Unit current) {
            AllowedTargets = targets.Living();
            TargetsEnumerator = AllowedTargets.GetEnumerator();
            TargetsEnumerator.MoveNext();
            current = TargetsEnumerator.Current;
            Reticle.Attach(current);
        }

        /// <summary>
        /// Start listening for targeting events
        /// </summary>
        private void BeginListening () {
            EventSystem.On<CycleNextTarget>(() => {
                Reticle.Attach(TargetsEnumerator.CycleNext());
            });

            EventSystem.On<CyclePrevTarget>(() => {
                Reticle.Attach(TargetsEnumerator.CycleReverse());
            });

            EventSystem.On<CommitSelection>(() => {
                if (Currently == TargetingState.Selecting)
                    TargeterSelected();
                else
                    TargetAcquired();
            });

            EventSystem.On<TurnOver>(Reinitialize);
        }

        // Use this for initialization
        void Start () {
            Reticle = GetComponent<Reticle>();
            BeginListening();
            Reinitialize();
        }
    }
}
