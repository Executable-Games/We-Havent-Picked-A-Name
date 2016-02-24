using UnityEngine;
using System.Collections;
// NOTE(jordan): List
using System.Collections.Generic;
// NOTE(jordan): List.All
using System.Linq;
using GameEvents;

namespace Combat {
    using Events;
    // NOTE(jordan): UnitsCollection
    using UnitGroups;
    /// <summary>
    /// Controller for the Combat Scene to figure out whose turn it is, etc.
    /// </summary>
    /// Author: Jordan (GitHub: @skorlir)
    /// 2/14/16 - Implement EndScreen()
    /// 2/13/16 - Add allies/enemies and reorganize
    /// 2/10/16
    public class Controller : MonoBehaviour {

        /// <summary>
        /// Number of seconds in a turn
        /// </summary>
        // NOTE(jordan): seconds for turns will probably be something we want to adjust
        public static readonly int turnInterval = 5;

        /// <summary>
        /// Public flag for whether it is the player's turn
        /// </summary>
        public static bool playerTurn = true;

        /// <summary>
        /// Ref to fancy shmancy CombatTimer
        /// </summary>
        // NOTE(jordan): every combat item needing a timer should refer to THIS timer.
        public static Timer CombatTimer;

        /// <summary>
        /// Enumerables of ally and enemy units
        /// </summary>
        public static UnitsCollection PlayerUnits;
        public static UnitsCollection EnemyUnits;

        /// <summary>
        /// Ref to CombatUI child object
        /// </summary>
        private GameObject CombatUI;

        /// <summary>
        /// Ref to CombatUIController
        /// </summary>
        private UIController UIController;

        /// <summary>
        /// The combat Stage object
        /// </summary>
        private GameObject Stage;

        /// <summary>
        /// UnitGroupControllers for player and enemy units
        /// </summary>
        private UnitGroupController EnemyUnitGroupController;
        private UnitGroupController PlayerUnitGroupController;

        /// <summary>
        /// Helper for initializing unit groups
        /// </summary>
        private void InitializeUnitGroups () {
            GameObject playerUnitsObj = Stage.transform.Find("Player Units").gameObject;
            GameObject enemyUnitsObj = Stage.transform.Find("Enemy Units").gameObject;

            PlayerUnitGroupController = playerUnitsObj.GetComponent<UnitGroupController>();
            EnemyUnitGroupController = enemyUnitsObj.GetComponent<UnitGroupController>();

            PlayerUnits = PlayerUnitGroupController.Units;
            EnemyUnits = EnemyUnitGroupController.Units;
        }

        // Use this for initialization
        void Awake () {
            Stage        = transform.Find("Stage").gameObject;
            CombatUI     = transform.Find("Combat UI").gameObject;
            CombatTimer  = GetComponent<Timer>();
            UIController = CombatUI.GetComponent<UIController>();

            InitializeUnitGroups();
        }

        void Start () {
            CombatTimer.Every(turnInterval, EventSystem.Trigger<TurnOver>);
            EventSystem.On<TurnOver>(OnTurnOver);
        }

        /// <summary>
        /// Action to run on each turn
        /// </summary>
        private void OnTurnOver () {
            // NOTE(jordan): Stop timer
            CombatTimer.Remove(turnInterval, EventSystem.Trigger<TurnOver>);

            if (!IsGameOver()) {
                // NOTE(jordan): switch turn
                playerTurn = !playerTurn;

                // NOTE(jordan): tell enemies to act
                if (!playerTurn) {
                    EnemyUnits.ForEach((enemy) => enemy.GetComponent<DumbAI>().TakeMove());
                }

                // NOTE(jordan): turn timer back on, resetting interval
                CombatTimer.Every(turnInterval, EventSystem.Trigger<TurnOver>);
            }
        }

        /// <summary>
        /// Checks if game is over and performs appropriate actions if so
        /// </summary>
        /// <returns></returns>
        private bool IsGameOver () {
            bool gameOver = false;

            if (PlayerUnits.All((au) => au.isDead)) {
                UIController.ShowEndScreen(false);
                gameOver = true;
            } else if (EnemyUnits.All((eu) => eu.isDead)) {
                UIController.ShowEndScreen(true);
                gameOver = true;
            }

            if (gameOver) {
                // NOTE(jordan): make sure timer is stopped
                CombatTimer.Remove(turnInterval, EventSystem.Trigger<TurnOver>);
            }

            return gameOver;
        }
    }
}
