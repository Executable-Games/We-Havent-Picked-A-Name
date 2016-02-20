using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace __ {
    /// <summary>
    /// NOTE: Not a replacement for "EventSystem", which are tied to Canvases! Similar name, slightly different function
    /// this allows "items to subscribe to events, and have events trigger". basically, an object can "listen" for an event, and upon hearing the proper event, invoke its related action (be triggered)
    /// </summary>
    /// Author: <Haley De Boom and the Unity Tutorial Guy> GitHub: dabomb2654
    public class EventManager : MonoBehaviour
    {
        public GameObject arrow;
        private Dictionary<string, UnityEvent> eventDictionary;
        private CombatUIController UIController;

        private static EventManager eventManager;

        //create and initialize ONE instance of EventManager 
        public static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        eventManager.Init();
                    }
                }

                return eventManager;
            }
        }
        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, UnityEvent>();
            }
        }

        /// <summary>
        /// if the event exists in the dictionary, give it a listener, otherwise create the event, add a listener, and add it to the dictionary
        /// </summary>

        public static void StartListening(string eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;

            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) //TryGetValue is a faster GetKey for dictionaries
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }
        /// <summary>
        /// if the event is in the dictionary, remove its listeners (important to do before deleting its related objects or events, otherwise you get memory leaks)
        /// </summary>

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (eventManager = null) return;
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }
       
        // if this event is in the dictionary, trigger it!
        public static void TriggerEvent(string eventName)
        {
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }

        //everything below this should be moved to CombatController once finalized

        void OnEnable()
        {
            EventManager.StartListening("TeacupAction", TeacupActionChoice);
            EventManager.StartListening("BearAction", BearActionChoice);
            EventManager.StartListening("PeggyAction", PeggyActionChoice);
            EventManager.StartListening("CrayonsAction", CrayonsActionChoice);
        }

        void OnDisable()
        {
            EventManager.StartListening("TeacupAction", TeacupActionChoice);
            EventManager.StartListening("BearAction", BearActionChoice);
            EventManager.StartListening("PeggyAction", PeggyActionChoice);
            EventManager.StartListening("CrayonsAction", CrayonsActionChoice);
        }

        void TeacupActionChoice()
        {
            Debug.Log("Teacup Triggered");
            Vector3 SpawnLocationT = GameObject.Find("CombatTeacup").transform.position + new Vector3(1, 1, 0);
            Debug.Log(SpawnLocationT);
            Instantiate(arrow, SpawnLocationT, Quaternion.identity);

        }
        void BearActionChoice()
        {
            Debug.Log("Bear Triggered");
            Vector3 SpawnLocationB = GameObject.Find("CombatBear").transform.position + new Vector3(1, 1, 0);
            Debug.Log(SpawnLocationB);
            Instantiate(arrow, SpawnLocationB, Quaternion.identity);
        }
        void PeggyActionChoice()
        {
            Debug.Log("Peggy Triggered");
            Vector3 SpawnLocationP = GameObject.Find("CombatPeggy").transform.position + new Vector3(1, 1, 0);
            Debug.Log(SpawnLocationP);
            Instantiate(arrow, SpawnLocationP, Quaternion.identity);
        }
        void CrayonsActionChoice()
        {
            Debug.Log("Crayons Triggered");
            Vector3 SpawnLocationC = GameObject.Find("CombatCrayons").transform.position + new Vector3(1, 1, 0);
            Debug.Log(SpawnLocationC);
            Instantiate(arrow, SpawnLocationC, Quaternion.identity);
        }

        void Update()
        {
            if (Input.GetKeyDown("w"))
            {
                EventManager.TriggerEvent("BearAction");
            }
            if (Input.GetKeyDown("a"))
            {
                EventManager.TriggerEvent("CrayonsAction");
            }
            if (Input.GetKeyDown("s"))
            {
                EventManager.TriggerEvent("PeggyAction");
            }
            if (Input.GetKeyDown("d"))
            {
                EventManager.TriggerEvent("TeacupAction");
            }
        }
      
    }
}