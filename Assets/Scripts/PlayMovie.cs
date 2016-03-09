using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {

            Renderer r = GetComponent<Renderer>();
            MovieTexture movie = (MovieTexture)r.material.mainTexture;
            Debug.Log("play?");
            if (movie.isPlaying)
            {
                movie.Pause();
            }
            else
            {
                movie.Play();
            }
        }
    }
}
