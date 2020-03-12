using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{

    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HoverSound() {
        myFx.clip = hoverFx;
        myFx.Play();
        //myFx.PlayOneShot(hoverFx, 0.7f);
    }

    public void ClickSound() {
        myFx.clip = clickFx;
        myFx.Play();

    }
}
