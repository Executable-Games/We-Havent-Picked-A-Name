using UnityEngine;
using System.Collections;
using GameEvents;
using Combat.Events;

namespace Combat.Units {
    /// <summary>
    /// Unit script for managing combat units
    /// </summary>
    /// Author: Jordan (GitHub: @skorlir)
    /// 2/13/16 - add public Health
    /// 2/11/16
    public class Unit : MonoBehaviour {
        /// <summary>
        /// Reference to Combat Controller
        /// </summary>
        private Controller Controller;

        /// <summary>
        /// Public player|enemy flag
        /// </summary>
        public bool isEnemy = true;

        /// <summary>
        /// Reference to combat health
        /// </summary>
        public Health Health;

        /// <summary>
        /// Determines if the Unit is dead or not
        /// </summary>
        /// <returns>True if health is 0; otherwise, return False</returns>
        public bool isDead {
            get {
                return this.Health.hp == 0;
            }
        }

        void Start () {
            Controller = transform.root.gameObject.GetComponent<Controller>();
            Health = GetComponent<Health>();

            // !DEBUG(aaron)
            //Controller.CombatTimer.After(0.25f, () => Debug.Log("Hello from Unit!"));
        }
    }
}