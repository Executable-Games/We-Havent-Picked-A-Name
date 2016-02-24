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
            Unit target = GetTarget();
            float hitChance = Random.Range(0f, EnemyAttack.Accuracy);
            if (hitChance >= 0.33f) {
                EnemyAttack.PerformAttack(target);
            } else {
                Debug.Log(string.Format("Enemy {0} missed!", enemy));
            }
        }

        private Unit GetTarget () {
            return targetOptions.Random();
        }

        public GameObject TargetGroup;
        public BasicAttack EnemyAttack;

        private UnitsCollection targetOptions;

        private GameObject enemyObj;
        private Unit enemy;

        void Start () {
            targetOptions = TargetGroup.GetComponent<UnitGroupController>().Units;
            enemyObj = transform.parent.gameObject;
            enemy = enemyObj.GetComponent<Unit>();
        }
    }
}
