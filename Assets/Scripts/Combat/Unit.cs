using UnityEngine;
using GameEvents;

namespace Combat {
    using Events;
    using Attacks;
    /// <summary>
    /// Unit script for managing combat units
    /// </summary>
    /// Author: Jordan (GitHub: @skorlir)
    /// 2/13/16 - add public Health
    /// 2/11/16
    public class Unit : MonoBehaviour {
        /// <summary>
        /// Public player|enemy flag
        /// </summary>
        public bool isEnemy = true;

        /// <summary>
        /// Unit's hit points
        /// </summary>
        public Health Health;

        /// <summary>
        /// Currently selected attack
        /// </summary>
        public IAttack CurrentlySelectedAttack;

        /// <summary>
        /// Determines if the Unit is dead
        /// </summary>
        /// <returns>True if health is 0; otherwise, return False</returns>
        public bool isDead {
            get {
                return this.Health.hp == 0;
            }
        }

        void Start () {
            Health = GetComponent<Health>();

            // TODO(jordan): extract this into a MovesList class
            CurrentlySelectedAttack = GetComponent<BasicAttack>();

            // !DEBUG(aaron)
            //Controller.CombatTimer.After(0.25f, () => Debug.Log("Hello from Unit!"));
        }
    }
}