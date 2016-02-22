using UnityEngine;
// NOTE(jordan): gives access to UI.Text
using UnityEngine.UI;
using System.Collections;
// NOTE(jordan): Generic namespace contains List
using System.Collections.Generic;
using GameEvents;

namespace Combat {
    using Events;
    /// <summary>
    /// Controller for Combat UI that can be used to show a message
    /// </summary>
    /// Author: Jordan (GitHub: @skorlir)
    /// 2/14/16 - Add EndScreen
    /// 2/10/16
    public class UIController : MonoBehaviour {
        /// <summary>
        /// UIText object to show/hide/change
        /// </summary>
        private Text UIText;

        /// <summary>
        /// UIText Container
        /// </summary>
        private GameObject UITextContainer;

        /// <summary>
        /// UI Message Panel
        /// </summary>
        private GameObject UIMessagePanel;

        /// <summary>
        /// End Screen
        /// </summary>
        // NOTE(jordan): this object is set in the Unity Inspector
        public GameObject EndScreen;

        /// <summary>
        /// Ref to CombatController CombatTimer component
        /// </summary>
        private Timer CombatTimer;

        /// <summary>
        /// Template strings for constructing a 'turn over!' message
        /// </summary>
        private string turnOverTemplate = "<b>Turn over!</b> It is now {0} turn.";
        private string playerTurnText = "<color=#44cc44>your</color>";
        private string enemyTurnText = "<color=#ff4444>enemy</color>";

        /// <summary>
        /// Construct a turn over message appropriate for the coming turn
        /// </summary>
        /// <returns>Turn over message with color information</returns>
        private string TurnOverMessage () {
            return string.Format(turnOverTemplate, Controller.playerTurn ? playerTurnText : enemyTurnText);
        }

        void Start () {
            CombatTimer = Controller.CombatTimer;
            // NOTE(jordan): this only works because CombatUI only has 1 child, and it's the MessagePanel
            UIMessagePanel = gameObject.transform.GetChild(0).gameObject;
            UITextContainer = UIMessagePanel.transform.GetChild(0).gameObject;
            UIText = UITextContainer.GetComponent<Text>();

            // NOTE(jordan): perform UI changes when turn control swaps
            EventSystem.On<TurnOver>(() => {
                // NOTE(jordan): set ui message
                SetMessage(TurnOverMessage());
                // NOTE(jordan): show message for 1/2 turnInterval seconds (needs to be less than turnInterval or it will show and hide at the same time ;) )
                Show(Controller.turnInterval / 2f);
            });
        }

        /// <summary>
        /// Sets the message text for UIText
        /// </summary>
        /// <param name="newMessage">string to use for new message</param>
        public void SetMessage (string newMessage) {
            // !DEBUG(jordan)
            //Debug.Log(string.Format("SetMessage to {0}", newMessage));
            UIText.text = newMessage;
        }

        /// <summary>
        /// Show UIText
        /// </summary>
        public void Show () {
            // !DEBUG(jordan)
            //Debug.Log(string.Format("Show! message w/ text: {0}", UIText.text));
            UITextContainer.SetActive(true);
        }

        /// <summary>
        /// Show UIText for a certain duration
        /// </summary>
        /// <param name="duration">Amount of time to wait before hiding</param>
        public void Show (float duration) {
            Show();
            CombatTimer.After(duration, delegate {
                // !DEBUG(jordan)
                //Debug.Log("Okay, now hide!");
                UITextContainer.SetActive(false);
            });
        }

        /// <summary>
        /// Show UIText for a certain number of seconds
        /// </summary>
        /// <see cref="Show(float)"/>
        public void Show (int seconds) {
            float duration = (float) seconds;

            Show(duration);
        }

        /// <summary>
        /// Hide UIText
        /// </summary>
        public void Hide () {
            UITextContainer.SetActive(false);
        }

    }
}