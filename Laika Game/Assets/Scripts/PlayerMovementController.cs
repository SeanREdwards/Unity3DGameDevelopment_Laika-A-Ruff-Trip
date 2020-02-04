using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovementController : MonoBehaviour
{

    public float move_speed;
    public float rotate_speed;

    public float jump_power;
    public Vector3 jump_vector;

    private Rigidbody rb;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump_power = 7.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move_vertical = Input.GetAxis("Vertical");
        float move_horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0.0f, 0.0f, move_vertical);
        transform.Rotate(0, move_horizontal * rotate_speed * Time.deltaTime, 0);

        if (move_vertical < 0)
        {
            //Dog moves slower when backing up
            transform.Translate(movement * (move_speed * .4f) * Time.deltaTime, Space.Self);
        }
        else
        {
            /*Allow for forward/backward movement.*/
            transform.Translate(movement * move_speed * Time.deltaTime, Space.Self);
        }


        /*For jumping.*/
        if ((Input.GetKeyDown("space") || Input.GetButtonDown("A")) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jump_power, 0), ForceMode.Impulse);
            isGrounded = false;
        }


        /*For gliding.*/
        if (!isGrounded)
        {
            /*If holding space player can glide.*/
            if ((Input.GetKey("space") || Input.GetButton("A")))
            {
                //Half gravity and propel forward slightly
                rb.useGravity = false;
                rb.AddForce(Physics.gravity * 0.5f * rb.mass);
                rb.AddForce(transform.forward * 2f);
            }
            else
            {
                //let go of jump button and gravity is reapplied.
                rb.useGravity = true;
            }
        }
        else
        {
            //Collision with ground causes reappliction of gravity as well.
            rb.useGravity = true;
        }                                                                                                                              
    }

    /*Set grounded condition.*/
    void OnCollisionEnter(Collision col)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
            //Debug.Log("Collided with ground.");
        }
    }
}
