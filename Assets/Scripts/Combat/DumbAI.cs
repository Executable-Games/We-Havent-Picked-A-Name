using UnityEngine;
using System.Collections;

namespace Combat {
    using UnitGroups;
    using Attacks;

    public class DumbAI : MonoBehaviour {
        /// <summary>
        /// Tell AI to make a move
        /// </summary>
        public void TakeMove () {
            if (HaveTargets()) {
                Unit target = GetTarget();
                float hitChance = Random.Range(0f, EnemyAttack.Accuracy);
                if (hitChance >= 0.33f) {
                    EnemyAttack.PerformAttack(target);
                } else {
                    Debug.Log(string.Format("Enemy {0} missed!", enemy));
                }
            } else {
                Debug.Log(string.Format("Enemy {0} has no valid targets.", enemy));
            }
        }

        private bool HaveTargets () {
            return Targets.Count > 0;
        }

        private Unit GetTarget () {
            return Targets.Random();
        }

        public GameObject TargetGroup;
        public BasicAttack EnemyAttack;

        private UnitsCollection targets;
        private UnitsCollection Targets {
            get {
                return targets.Living();
            }
        }

        private GameObject enemyObj;
        private Unit enemy;

        void Start () {
            targets = TargetGroup.GetComponent<UnitGroupController>().Units;
            enemyObj = transform.parent.gameObject;
            enemy = enemyObj.GetComponent<Unit>();
        }
    }
}
