using UnityEngine;
using System.Collections;
using System.Linq;

using GameEvents;

namespace Combat {
    using Events;
    using UnitGroups;
    /// <summary>
    /// TargetSelector behaviour for combat target selection
    /// </summary>
    /// Author: Jordan (GitHub: @skorlir)
    /// 2/22/16
    public class Reticle : Attach {
        /// <summary>
        /// GameObject containing a UnitGroupController
        /// </summary>
        public GameObject targetGroup;

        /// <summary>
        /// UnitsCollection of targets that can be selected by this selector
        /// </summary>
        private UnitsCollection allowedTargets;
        private UnitsCollection moveablePlayerUnits;

        /// <summary>
        /// UnitsEnumerator for cycling between allowed targets
        /// </summary>
        private UnitsEnumerator targetsEnumerator;

        /// <summary>
        /// Currently selected Unit
        /// </summary>
        private Unit selectedUnit;

        /// <summary>
        /// Previously selected player Unit
        /// </summary>
        private Unit playerUnit;

        /// <summary>
        /// Enum for Reticle states
        /// </summary>
        public enum ReticleState {
            Targeting, Selecting
        }

        /// <summary>
        /// Current reticle state
        /// </summary>
        public ReticleState Currently = ReticleState.Selecting;

        /// <summary>
        /// Convenience method for targeting the currently selected unit
        /// </summary>
        private void Target () {
            switch (Currently) {
                case ReticleState.Targeting:
                    // TODO(jordan): not sure this is perfect, but it'll work for now
                    float dmg = playerUnit.CurrentlySelectedAttack.PerformAttack(selectedUnit);
                    Debug.Log(string.Format("<color=#00ff00>Attacked enemy</color> {0} for {1} damage, to {2} hp", selectedUnit, dmg, selectedUnit.Health.hp));
                    allowedTargets = moveablePlayerUnits;
                    GetComponent<SpriteRenderer>().flipX = false;
                    attachPoint = AttachPoint.TopRight;
                    Currently = ReticleState.Selecting;

                    moveablePlayerUnits.Remove(playerUnit);

                    if (moveablePlayerUnits.Count() == 0) {
                        // TODO(jordan): do what you do when you're done selecting moves
                        EventSystem.Trigger<TurnOver>();
                    }
                    break;
                case ReticleState.Selecting:
                    playerUnit = selectedUnit;
                    allowedTargets = Controller.EnemyUnits;
                    attachPoint = AttachPoint.TopLeft;
                    GetComponent<SpriteRenderer>().flipX = true;
                    // TODO(jordan): show moveslist
                    Currently = ReticleState.Targeting;
                    break;
            }
            targetsEnumerator = allowedTargets.GetEnumerator();
            Attach(allowedTargets.ElementAt(0));
        }

        /// <summary>
        /// Convenience method for attaching to a unit
        /// </summary>
        /// <param name="u"></param>
        private void Attach (Unit u) {
            selectedUnit = u;
            attachTarget = u.gameObject;
            AttachToTarget();
            Debug.Log(string.Format("selectedUnit {0}", selectedUnit));
            Debug.Log(string.Format("playerUnit {0}", playerUnit));
        }

        // NOTE(jordan): initialize all references
        void Awake () {
            allowedTargets = targetGroup.GetComponent<UnitGroupController>().Units;
            targetsEnumerator = allowedTargets.GetEnumerator();
            Debug.Log(string.Format("allowedTargets: {0}", allowedTargets));
        }

        // NOTE(jordan): set attach points
        void OnEnable () {
            attachPoint = AttachPoint.TopRight;
            GetComponent<SpriteRenderer>().flipX = false;
            AttachToTarget();
        }

        void Start () {
            selectedUnit = allowedTargets.ElementAt(0);
            moveablePlayerUnits = new UnitsCollection(Controller.PlayerUnits);
            Debug.Log(string.Format("moveablePlayerUnits: {0}", moveablePlayerUnits));
            // NOTE(jordan): events will be called on user input
            // NOTE(jordan): press space / confirm
            EventSystem.On<CommitSelection>(() => {
                Target();
            });

            // NOTE(jordan): unimplmented: click select
            EventSystem.On<TargetSelected, Unit>((u) => {
                if (allowedTargets.Contains(u)) {
                    Attach(u);
                    Target();
                }
            });

            // NOTE(jordan): 'W' cycle next
            EventSystem.On<CycleNextTarget>(() => {
                Unit u = targetsEnumerator.CycleNext(selectedUnit);
                Attach(u);
            });

            // NOTE(jordan): 'S' cycle previous
            EventSystem.On<CyclePrevTarget>(() => {
                Unit u = targetsEnumerator.CycleReverse(selectedUnit);
                Attach(u);
            });

            // NOTE(jordan): when turn ends, reset
            EventSystem.On<TurnOver>(() => {
                allowedTargets = moveablePlayerUnits = new UnitsCollection(Controller.PlayerUnits);
                Attach(moveablePlayerUnits.ElementAt(0));
                Currently = ReticleState.Selecting;
            });
        }
    }
}