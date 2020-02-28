using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCollectSoundEffect : MonoBehaviour
{
    public bool play;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            GetComponent<AudioSource>().Play();
            play = false;
        }
    }
}
