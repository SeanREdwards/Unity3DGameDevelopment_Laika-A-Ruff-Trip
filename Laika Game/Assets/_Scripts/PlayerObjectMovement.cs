﻿using UnityEngine;
using System.Collections;

public class PlayerObjectMovement : MonoBehaviour
{


    public float speed;
    public bool canHold = true;
    public GameObject ball;
    public Transform guide;
    float yHold;
    GameObject ppParticles;
    public GameObject head;
    public AudioSource ads;
    public GameObject tooltip;

    void Update()
    {
        if (Input.GetKeyDown("e") || Input.GetButtonDown("X"))
        {
            if (!canHold)
            {
                throw_drop();
                CancelInvoke();
            }
            else
            {
                if (ball != null)
                {
                    ball.transform.position = guide.position;
                    InvokeRepeating("Pickup", 0f, .015f);

                }
            }
        }
/*
        if (!canHold && ball)
            ball.transform.position = guide.position;
            */
    }//update

    //We can use trigger or Collision
    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Pickup")
            if (!ball) // if we don't have anything holding
                ball = col.gameObject;
    }

    //We can use trigger or Collision
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            if (canHold)
                ball = null;
        }
    }


    IEnumerator Pickup2()
    {
        yield return null;
    }

    private void Pickup()
    {
        tooltip.SetActive(false);
        /*
        if (!ball)
            return;
            */

        if (!ads.isPlaying)
        {
            ads.Play();
        }

        //We set the object parent to our guide empty object.
        if (ball != null)
        {
            ball.transform.SetParent(guide);
        } else
        {
            throw_drop();
            CancelInvoke();
            return;
        }
        if (transform.childCount >= 10 && transform.GetChild(9).gameObject.name == "Pickup Particles")
        {

            ppParticles = transform.GetChild(9).gameObject;
            ppParticles.SetActive(true);
            ppParticles.transform.SetParent(ball.transform);
            ppParticles.transform.position = ball.transform.position;
        }
        //Set gravity to false while holding it
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().isKinematic = true;

        //we apply the same rotation our main object (Camera) has.
        ball.transform.localRotation = transform.rotation;
        //We re-position the ball on our guide object 
        //ball.transform.position = guide.position;
        Vector3 pos = ball.transform.localPosition;
        if (Input.GetKey("i") && pos.z <= 1.5f)
        {
            pos.z += .05f;
            ball.transform.localPosition = pos;

        }
        else if (Input.GetKey("k") && pos.z >= -0.5f)
        {
            pos.z -= 0.05f;
            ball.transform.localPosition = pos;

        } else if (Input.GetKey("j") && pos.x >= -1.5f)
        {
            pos.x -= .05f;
            ball.transform.localPosition = pos;
        } else if (Input.GetKey("l") && pos.x <= 1.5f)
        {
            pos.x += .05f;
            ball.transform.localPosition = pos;
        }



        canHold = false;
    }

    public void throw_drop()
    {
        /*
        if (!ball)
            return;
*/
        //Set our Gravity to true again.
        if (ball != null)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (ads.isPlaying)
        {
            ads.Stop();
        }


        if (ppParticles != null)
        {
            ppParticles.transform.SetParent(transform);
            ppParticles.transform.SetSiblingIndex(9);
            ppParticles.transform.position = transform.position;
            ppParticles.SetActive(false);
        }

        // we don't have anything to do with our ball field anymore
        ball = null;
        //Apply velocity on throwing
        if (guide.childCount != 0)
        {
            guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

            //Unparent our ball
            guide.GetChild(0).parent = null;
        }
        canHold = true;
        CancelInvoke();
    }
}//class