using UnityEngine;
using System.Collections;
// NOTE(jordan): List
using System.Collections.Generic;
// NOTE(jordan): UnitsCollection
using UnitGroups;
// NOTE(jordan): List.All
using System.Linq;
using GameEvents;
using Combat.Events;
using Combat.Units;

namespace Combat {
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
        // NOTE(jordan): 5 seconds for turns will probably be something we want to adjust
        public int turnInterval = 5;

        /// <summary>
        /// Public flag for whether it is the player's turn
        /// </summary>
        public bool playerTurn = true;

        /// <summary>
        /// Ref to CombatUI child object
        /// </summary>
        private GameObject CombatUI;

        /// <summary>
        /// Ref to CombatUIController
        /// </summary>
        private UIController UIController;

        /// <summary>
        /// Ref to fancy shmancy CombatTimer
        /// </summary>
        // NOTE(jordan): every combat item needing a timer should refer to THIS timer.
        public Timer CombatTimer;

        /// <summary>
        /// The combat Stage object
        /// </summary>
        private GameObject Stage;

        /// <summary>
        /// The End Screen object
        /// </summary>
        private GameObject EndDisplay;

        /// <summary>
        /// Enumerables of ally and enemy units
        /// </summary>
        private UnitsCollection PlayerUnits;
        private UnitsCollection EnemyUnits;

        /// <summary>
        /// UnitGroupControllers for player and enemy units
        /// </summary>
        private UnitGroupController EnemyUnitGroupController;
        private UnitGroupController PlayerUnitGroupController;

        // Run before Units Start
        void Awake () {
            EventSystem.On<UnitLives, Unit>((unit) => Debug.Log(string.Format("Unit {0} is alive!", unit)));
        }

        // Use this for initialization
        void Start () {
            Stage        = transform.Find("Stage").gameObject;
            CombatUI     = transform.Find("Combat UI").gameObject;
            CombatTimer  = GetComponent<Timer>();
            UIController = CombatUI.GetComponent<UIController>();
            EndDisplay   = UIController.EndScreen;

            EndDisplay.SetActive(false);

            InitializeUnitGroups();

            CombatTimer.Every(turnInterval, OnTurn);
        }

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

        /// <summary>
        /// Action to run on each turn
        /// </summary>
        private void OnTurn () {
            // NOTE(jordan): Stop timer on Game Over
            if (GameOver()) {
                CombatTimer.Remove(turnInterval, OnTurn);
                return;
            }

            // NOTE(jordan): switch turn
            playerTurn = !playerTurn;

            EventSystem.Trigger<TurnOver>();
        }

        /// <summary>
        /// Checks if game is over and performs appropriate actions if so
        /// </summary>
        /// <returns></returns>
        private bool GameOver () {
            if (PlayerUnits.All((au) => au.isDead)) {
                EndScreen(true);
                return true;
            }

            if (EnemyUnits.All((eu) => eu.isDead)) {
                EndScreen(false);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Displays the end screen
        /// Different display based on victory of defeat (T/F)
        /// </summary>
        private void EndScreen (bool victory) {
            //NOTE(aaron): not implemented yet
            EndDisplay.SetActive(true);
        }
    }
}
