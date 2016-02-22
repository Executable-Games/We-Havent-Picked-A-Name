using UnityEngine;
using System;

namespace Combat {
    using UnitGroups;
    /// <summary>
    /// Script for handling health of units in combat
    /// </summary>
    /// Author: Jordan (GitHub: @skorlir)
    /// 2/10/16
    public class Health : MonoBehaviour {
        /// <summary>
        /// Public maximum HP
        /// </summary>
        public const float MAX_HP = 1f;

        /// <summary>
        /// Public current HP
        /// </summary>
        public float hp = MAX_HP;

        /// <summary>
        /// Private struct for representing health change type
        /// </summary>
        // FUTURE(jordan): consider a HealthChangeType like 'boost' that can increase HP past MAX, for instance
        private enum HealthChangeType {
            Heal,
            Damage
        }

        /// <summary>
        /// Generalized private health diff calculation function
        /// </summary>
        /// <param name="changeType">HealthChangeType representing type of change</param>
        /// <param name="amount">Integer change</param>
        /// <returns>|change in HP|</returns>
        private float ChangeHealth (HealthChangeType changeType, float amount) {
            float diff = 0;

            switch (changeType) {
                case HealthChangeType.Damage:
                    diff = hp - amount < 0 ? 0 : -amount;
                    break;
                case HealthChangeType.Heal:
                    diff = hp + amount > MAX_HP ? MAX_HP - hp : amount;
                    break;
                default:
                    // NOTE(jordan): use UnityEngine's Debug, not System's Console.WriteLine
                    Debug.LogError(string.Format("Unrecognized HealthChangeType: {0}", changeType));
                    break;
            }

            Debug.Log(string.Format("HP Change: {0}", diff));
            hp += diff;
            return diff;
        }

        /// <summary>
        /// Damage this unit
        /// </summary>
        /// <param name="damageAmount">Integer amount of damage to do</param>
        /// <returns>change in HP</returns>
        public float Damage (float damageAmount) {
            float healthChange = ChangeHealth(HealthChangeType.Damage, damageAmount);

            if (hp == 0) {
                Die();
            }

            return healthChange;
        }

        /// <summary>
        /// Heal this unit
        /// </summary>
        /// <param name="healAmount">Integer amount of healing to do</param>
        public float Heal (float healAmount) {
            return ChangeHealth(HealthChangeType.Heal, healAmount);
        }

        /// <summary>
        /// Perform cleanup and any other pre-death actions, then destroy this gameObject
        /// </summary>
        private void Die () {
            // NOTE(jordan): remove self from unit group
            GetComponentInParent<UnitGroupController>().Units.Remove(GetComponentInParent<Unit>());
            Destroy(gameObject);
        }
    }
}