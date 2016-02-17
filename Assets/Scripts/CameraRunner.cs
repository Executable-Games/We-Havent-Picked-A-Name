using UnityEngine;
using System.Collections;

public class CameraRunner : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    void start () {
    }

    void Update () 
    {
        transform.position = new Vector3 (player.position.x + offset.x, 0, offset.z); // Camera follows the player with specified offset position
    }
}
