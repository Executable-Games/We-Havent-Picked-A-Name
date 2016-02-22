using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Generic Script for attaching objects to other objects (position-wise)
/// </summary>
/// Author: Aaron (Github: @aaronkarp123)
/// 2/15/16
public class Attach : MonoBehaviour {

    public AttachPoint attachPoint;
    public GameObject target;
    
    // Update is called once per frame
    void Update () {
        OnAttach();
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
        OnAttach();
    }

    /// <summary>
    /// Attaches this object to 'target' at 'point'
    /// </summary>
    /// <param name="point">Point to attach to.</param>
    /// <param name="target">Target object.</param>
    void OnAttach ()
    {
        //Bounds bounds = target.GetComponent<Mesh> ().bounds;
        Bounds bounds = target.GetComponent<Renderer>().bounds;
        float width = bounds.size.x;
        float height = bounds.size.y;
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
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
