using UnityEngine;
using System.Collections;
// NOTE(jordan): List
using System.Collections.Generic;
// NOTE(jordan): Action
using System;

/// <summary>
/// A generic Timer for to use on any of the things
/// </summary>
/// Author: Jordan (GitHub: @skorlir)
/// 2/10/2016
public class Timer : MonoBehaviour {

    /// <summary>
    /// Cumulative timer
    /// </summary>
    private float timer = 0;

    /// <summary>
    /// IntervalAction wrapper
    /// </summary>
    public struct IntervalAction {
        public bool selfDestruct;
        public Action action;
        public float lastRunTime;

        public IntervalAction (Action a) {
            action       = a;
            selfDestruct = false;
            lastRunTime  = 0f;
        }
    }

    /// <summary>
    /// Intervals for easy iteration without creating a new List on each Update()
    /// </summary>
    List<float> Intervals = new List<float>();

    /// <summary>
    /// Dictionary for quick access of IntervalActionSets for a given interval
    /// </summary>
    private Dictionary<float, List<IntervalAction>> IntervalActions = new Dictionary<float, List<IntervalAction>>();

    /// <summary>
    /// Reset timer: set cumulative timer back to 0
    /// </summary>
    private void Reset () {
        timer = 0;
    }

    /// <summary>
    /// Convenience method for creating a new trigger interval that hasn't been used yet
    /// </summary>
    /// <param name="t">Interval interval (float)</param>
    /// <param name="initialAction">Action being added for that interval</param>
    private void NewInterval (float t, IntervalAction initialAction) {
        Intervals.Add(t);

        initialAction.lastRunTime = timer;

        List<IntervalAction> intervalActionSet = new List<IntervalAction>();
        intervalActionSet.Add(initialAction);

        IntervalActions.Add(t, intervalActionSet);
    }

    /// <see cref="NewInterval(float, IntervalAction)"/>
    private void NewInterval (float t, Action initialAction) {
        IntervalAction action = new IntervalAction(initialAction);
        NewInterval(t, action);
    }

    /// <summary>
    /// Run callback at every (float) interval
    /// </summary>
    /// <param name="interval">Interval (in high-precision part-seconds) to call callback on</param>
    /// <param name="callback">Callback to call</param>
    public void Every (float interval, Action callback) {
        List<IntervalAction> ias = new List<IntervalAction>();

        if (IntervalActions.ContainsKey(interval)) {
            ias = IntervalActions[interval];

            IntervalAction newAction = new IntervalAction(callback);
            newAction.lastRunTime = timer;

            ias.Add(newAction);
        } else {
            NewInterval(interval, callback);
        }
    }

    /// <see cref="Every(float, Action)"/>
    public void Every (int seconds, Action callback) {
        float interval = (float) seconds;

        Every(interval, callback);
    }

    /// <see cref="Every(float, Action)"/>
    public void Every (float interval, IntervalAction callback) {
        List<IntervalAction> ias = new List<IntervalAction>();

        if (IntervalActions.ContainsKey(interval)) {
            ias = IntervalActions[interval];
            ias.Add(callback);
        } else {
            NewInterval(interval, callback);
        }
    }

    /// <summary>
    /// Run callback action after interval seconds
    /// </summary>
    /// <param name="interval">Number of seconds to wait</param>
    /// <param name="callback">Action to perform after interval seconds</param>
    public void After (float interval, Action callback) {
        IntervalAction action = new IntervalAction(callback);
        action.lastRunTime  = timer;
        action.selfDestruct = true;

        // NOTE(jordan): I get that this is a little confusing, but the action will selfDestruct. Trust me.
        Every(interval, action);
    }


    /// <see cref="After(float, Action)"/>
    public void After (int seconds, Action callback) {
        float interval = (float) seconds;

        After(interval, callback);
    }

    /// <summary>
    /// Remove an IntervalAction for a given interval if that callback is set
    /// </summary>
    /// <param name="interval">Interval the callback is set to</param>
    /// <param name="callback">Ref to the IntervalAction to remove</param>
    public void Remove (float interval, IntervalAction callback) {
        if (IntervalActions.ContainsKey(interval)) {
            List<IntervalAction> ias = IntervalActions[interval];
            ias.Remove(callback);
        }
    }

    /// <summary>
    /// Remove a callback for a given interval from the original action
    /// </summary>
    /// <param name="interval">Interval the callback is set to</param>
    /// <param name="callback">Ref to the Action to remove</param>
    public void Remove (float interval, Action callback) {
        if (IntervalActions.ContainsKey(interval)) {
            List<IntervalAction> ias = IntervalActions[interval];
            IntervalAction toRemove = ias.Find( ia => ia.action == callback);
            ias.Remove(toRemove);
        }
    }
 
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        int i, j;

        // NOTE(jordan): pretty bad complexity here, ~O(n^2)
        for (i = 0; i < Intervals.Count; i++) { 
            float interval           = Intervals[i];
            List<IntervalAction> ias = IntervalActions[interval];

            for (j = 0; j < ias.Count; j++) {
                IntervalAction cb = ias[j];

                float lastRunTime     = cb.lastRunTime;
                float diff_t          = timer - lastRunTime;

                if (diff_t > interval) {

                    // !DEBUG(jordan)
                    //Debug.Log(string.Format("Trigger stats:\n\tInterval: {0}\tLastRunTime: {1}\tDiff_t: {2}", interval, lastRunTime, diff_t));

                    cb.action();
                    // NOTE(jordan): this permits After()
                    if (cb.selfDestruct) {
                        // !DEBUG(jordan)
                        //Debug.Log(string.Format("Remove this callback! {0}", cb));
                        ias.Remove(cb);
                    } else {
                        cb.lastRunTime = timer;
                        // NOTE(jordan): this is dumb, but that's how c# works
                        ias[j] = cb;
                    }
                }
            }
        }
    }
}
