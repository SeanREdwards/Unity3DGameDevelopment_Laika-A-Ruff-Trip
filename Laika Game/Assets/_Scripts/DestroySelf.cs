using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public GameObject sound;

    void SoundOffAndDestroy()
    {
        //Ready sound effect for next play
        sound.gameObject.SetActive(false);
        //Destroy gameobject altogether
        Destroy(this.transform.gameObject);
    }

    //Enable all colliders, mesh collider and trigger collider
    public void SetAllCollidersStatus(bool active)
    {
        foreach (Collider c in this.GetComponents<Collider>())
        {
            c.enabled = active;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If hit by a bullet
        if(other.gameObject.tag == "Bullet")
        {
            //Play sound effect
            sound.gameObject.SetActive(true);
            //Turn sound off and destory in 1.5s
            Invoke("SoundOffAndDestroy", 1.5f);

            //Turn off colliders and mesh rendered for the 1.5s
            this.GetComponent<MeshRenderer>().enabled = false;
            SetAllCollidersStatus(false);
        }
    }
}
