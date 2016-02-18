using UnityEngine;
using System.Collections;

/// <summary>
/// Class for Camera to Follow Player
/// </summary>
/// Author: Aaron (GitHub: @aaronkarp123)
/// 2/16/2016
public class CameraRunner : MonoBehaviour {

    /// <summary>
    /// Character for camera to follow
    /// </summary>
    public Transform player;

    /// <summary>
    /// Vector to add an offset to the following motion (should default to 0)
    /// </summary>
    public Vector3 offset;

    void start () {
    }

    void Update () 
    {
        transform.position = new Vector3 (player.position.x + offset.x, 0, offset.z); // Camera follows the player with specified offset position
    }
}
