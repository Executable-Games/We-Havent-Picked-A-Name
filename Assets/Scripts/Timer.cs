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
    /// IntervalAction wrapper
    /// </summary>
    public struct IntervalAction {
        public bool SelfDestruct;
        public Action Action;
        public float LastRunTime;
        public float Interval;

        public IntervalAction (float interval, Action a) {
            Action       = a;
            Interval     = interval;
            SelfDestruct = false;
            LastRunTime  = 0f;
        }
    }

    /// <summary>
    /// Cumulative timer
    /// </summary>
    private float timer = 0;

    /// <summary>
    /// Dictionary for quick access of IntervalActionSets for a given interval
    /// </summary>
    private List<IntervalAction> IntervalActions = new List<IntervalAction>();

    /// <summary>
    /// Reset timer: set cumulative timer back to 0
    /// </summary>
    private void Reset () {
        timer = 0;
    }

    /// <summary>
    /// Set LastRunTime and register an IntervalAction
    /// </summary>
    /// <param name="action">IntervalAction to register</param>
    private void RegisterIntervalAction (IntervalAction action) {
        action.LastRunTime = timer;
        IntervalActions.Add(action);
    }

    /// <summary>
    /// Run callback at every (float) interval
    /// </summary>
    /// <param name="interval">Interval (in high-precision part-seconds) to call callback on</param>
    /// <param name="callback">Callback to call</param>
    public void Every (float interval, Action callback) {
        IntervalAction ia = new IntervalAction(interval, callback);
        RegisterIntervalAction(ia);
    }

    /// <see cref="Every(float, IntervalAction)"/>
    public void Every (int seconds, Action callback) {
        float interval = (float) seconds;
        Every(interval, callback);
    }

    /// <summary>
    /// Run callback action after interval seconds
    /// </summary>
    /// <param name="interval">Number of seconds to wait</param>
    /// <param name="callback">Action to perform after interval seconds</param>
    public void After (float interval, Action callback) {
        IntervalAction ia = new IntervalAction(interval, callback);
        ia.SelfDestruct = true;
        RegisterIntervalAction(ia);
    }


    /// <see cref="After(float, Action)"/>
    public void After (int seconds, Action callback) {
        float interval = (float) seconds;

        After(interval, callback);
    }

    /// <summary>
    /// Remove an IntervalAction for a given interval if that callback is set
    /// </summary>
    /// <param name="callback">Ref to the IntervalAction to remove</param>
    public bool Remove (IntervalAction callback) {
        return IntervalActions.Remove(callback);
    }

    /// <summary>
    /// Remove a callback for a given interval from the original action
    /// </summary>
    /// <param name="interval">Interval the callback is set to</param>
    /// <param name="callback">Ref to the Action to remove</param>
    public bool Remove (float interval, Action callback) {
        IntervalAction toRemove;
        toRemove = IntervalActions.Find(ia => ia.Interval == interval && ia.Action == callback);
        return toRemove.Interval == -1f ? false : Remove(toRemove);
    }
 
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        int i = 0;

        for (; i < IntervalActions.Count; i++) {
            IntervalAction cb = IntervalActions[i];

            float lastRunTime = cb.LastRunTime;
            float diff_t      = timer - lastRunTime;

            if (diff_t > cb.Interval) {

                // !DEBUG(jordan)
                //Debug.Log(string.Format("Trigger stats:\n\tInterval: {0}\tLastRunTime: {1}\tDiff_t: {2}", interval, lastRunTime, diff_t));

                cb.Action();
                // NOTE(jordan): this permits After()
                if (cb.SelfDestruct) {
                    // !DEBUG(jordan)
                    //Debug.Log(string.Format("Remove this callback! {0}", cb));
                    IntervalActions.Remove(cb);
                } else {
                    cb.LastRunTime = timer;
                    // NOTE(jordan): this is dumb, but that's how c# works
                    IntervalActions[i] = cb;
                }
            }
        }
    }
}
