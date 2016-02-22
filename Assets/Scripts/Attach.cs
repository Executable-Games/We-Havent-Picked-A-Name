using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generic Script for attaching objects to other objects (position-wise)
/// </summary>
/// Author: Aaron (Github: @aaronkarp123)
/// Modified 2/22/16 - check if target has moved before reattaching (Jordan)
/// 2/15/16
public class Attach : MonoBehaviour {

    public AttachPoint attachPoint;
    public GameObject target;

    private Bounds targetBounds;
    private Vector3 targetPosition;

    /// <summary>
    /// Checks if target position has changed
    /// </summary>
    /// <returns>True if target position has changed</returns>
    private bool TargetPositionChanged () {
        return !target.transform.position.Equals(targetPosition);
    }

    /// <summary>
    /// Checks if target size has changed
    /// </summary>
    /// <returns>True if target size has changed</returns>
    private bool TargetSizeChanged () {
        Bounds currentBounds = target.GetComponent<Renderer>().bounds;
        return !currentBounds.size.Equals(targetBounds);
    }
    
    // Update is called once per frame
    void Update () {
        // NOTE(jordan): only reattach if target has moved or scaled.
        if (TargetPositionChanged() || TargetSizeChanged())
            AttachToTarget();
    }

    /// <summary>
    /// Enum for different possible attach points
    /// </summary>
    public enum AttachPoint {
        TopLeft, TopRight, BottomLeft, BottomRight, TopCenter, BottomCenter
    };

    /// <summary>
    /// Create the attach point
    /// </summary>
    void Start () 
    {
        AttachToTarget();
    }

    /// <summary>
    /// Attaches this object to 'target' at 'point'
    /// </summary>
    /// <param name="point">Point to attach to.</param>
    /// <param name="target">Target object.</param>
    void AttachToTarget ()
    {
        targetBounds = target.GetComponent<Renderer>().bounds;
        targetPosition = target.transform.position;
       
        float width = targetBounds.size.x;
        float height = targetBounds.size.y;
        float targetX = targetPosition.x;
        float targetY = targetPosition.y;
        //NOTE (aaron): Ideally this would be independent of anchor/pivot position, but I cannot find a way to abstract
        //the local relative position of this position within the object. Therefore, this currently only works for objects
        //with centered pivots.
        switch (attachPoint) {
            case AttachPoint.TopLeft:
                transform.position = new Vector3(targetX - width / 2, targetY - height / 2, 0);
                break;
            case AttachPoint.TopRight:
                transform.position = new Vector3(targetX + width / 2, targetY - height / 2, 0);
                break;
            case AttachPoint.BottomLeft:
                transform.position = new Vector3(targetX - width / 2, targetY + height / 2, 0);
                break;
            case AttachPoint.BottomRight:
                transform.position = new Vector3(targetX + width / 2, targetY + height / 2, 0);
                break;
            case AttachPoint.TopCenter:
                transform.position = new Vector3(targetX, targetY - height / 2, 0);
                break;
            case AttachPoint.BottomCenter:
                transform.position = new Vector3(targetX, targetY + height / 2, 0); 
                break;
        }
    }
}
