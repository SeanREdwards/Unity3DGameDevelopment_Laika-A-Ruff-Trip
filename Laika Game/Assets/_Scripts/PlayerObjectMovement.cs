using UnityEngine;
using System.Collections;

public class PlayerObjectMovement : MonoBehaviour
{


    public float speed;
    public bool canHold = true;
    public GameObject ball;
    public Transform guide;
    float yHold;
    public GameObject head;
    

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
                }
                InvokeRepeating("Pickup", 0f, .015f);
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
        /*
        if (!ball)
            return;
            */

        //We set the object parent to our guide empty object.
        ball.transform.SetParent(guide);

        //Set gravity to false while holding it
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().isKinematic = true;

        //we apply the same rotation our main object (Camera) has.
        ball.transform.localRotation = transform.rotation;
        //We re-position the ball on our guide object 
        //ball.transform.position = guide.position;
        Vector3 pos = ball.transform.localPosition;
        if (Input.GetKey("p"))
        {
            pos.z += .05f;
            ball.transform.localPosition = pos;

        }
        else if (Input.GetKey("o"))
        {
            pos.z -= 0.05f;
            ball.transform.localPosition = pos;

        } else if (Input.GetKey("k"))
        {
            pos.x += -.05f;
            ball.transform.localPosition = pos;
        } else if (Input.GetKey("l"))
        {
            pos.x -= -.05f;
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
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().isKinematic = false;

        // we don't have anything to do with our ball field anymore
        ball = null;
        //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Unparent our ball
        guide.GetChild(0).parent = null;
        canHold = true;
        CancelInvoke();
    }
}//class