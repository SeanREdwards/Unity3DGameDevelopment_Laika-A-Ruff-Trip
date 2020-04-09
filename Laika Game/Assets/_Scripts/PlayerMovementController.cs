using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovementController : MonoBehaviour
{

    public float move_speed;
    public float rotate_speed;
    public float sprint_mod;
    public bool limiter;
    public float jump_power;
    public Vector3 jump_vector;
    public AudioSource ads;
    public float glide_power;

    private Rigidbody rb;

    public bool isGrounded;
    public bool isSprinting;
    public bool isGliding;
    bool onePlay = false;
    public bool isPaused;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump_power = 4.0f;
        glide_power = 5.0f;
        sprint_mod = 2.0f;
        limiter = true;
        isSprinting = false;
        isGliding = false;
        isPaused = false;
    }

    void LimiterTrue()
    {

    }
    void Update()
    {
        if (isGrounded)
        {
            ads.Stop();
        }

        if (Input.GetKey("left shift"))
        {
            GetComponent<AudioSource>().pitch = 1.2f;
        } else
        {
            GetComponent<AudioSource>().pitch = 0.9f;
        }

        if (isPaused) {
            return;
        }

        if (onePlay)
        {
            onePlay = false;
            GetComponent<AudioSource>().Play();
        }

        /*For jumping.*/
        if ((Input.GetKeyDown("space") || Input.GetButtonDown("A")) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jump_power, 0), ForceMode.Impulse);
            isGrounded = false;
            GetComponent<AudioSource>().Stop();
            transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
        }

    }

    void FootStepSounds()
    {
        if (!movement.Equals(new Vector3(0f, 0f, 0f)) && isGrounded)
        {
           if (!GetComponent<AudioSource>().isPlaying)
            {
                onePlay = true;
            }
        }
        else if (!isGrounded)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(isPaused) {
            return;
        }

        float move_vertical = Input.GetAxis("Vertical");
        float move_horizontal = Input.GetAxis("Horizontal");

        movement = new Vector3(0.0f, 0.0f, move_vertical);
        transform.Rotate(0, move_horizontal * rotate_speed * Time.deltaTime, 0);

        if (move_vertical < 0)
        {
            isSprinting = false;

            //Dog moves slower when backing up
            transform.Translate(movement * (move_speed * .4f) * Time.deltaTime, Space.Self);
            FootStepSounds();
        }
        else
        {
            FootStepSounds();

            /*Allow for forward movement.*/
            if (!(Input.GetKey("left shift") || Input.GetButton("LeftBumper")))
            {

                isSprinting = false;

                transform.Translate(movement * move_speed * Time.deltaTime, Space.Self);

            }

            /*Allows for sprinting.*/
            else
            {
                isSprinting = true;
                transform.Translate(movement * (move_speed * sprint_mod) * Time.deltaTime, Space.Self);
            }

        }

        /*For gliding.*/
        if (!isGrounded)
        {
            /*If holding space player can glide.*/
            if ((Input.GetKey("space") || Input.GetButton("A")))
            {
                //Half gravity and propel forward slightly
                rb.useGravity = false;
                isGliding = true;
                rb.AddForce(Physics.gravity * 0.5f * rb.mass);
                rb.AddForce(transform.forward * glide_power);
                if (!ads.isPlaying)
                {
                    ads.Play();
                }
            }
            else
            {
                if (ads.isPlaying)
                {
                    ads.Stop();
                }
                //let go of jump button and gravity is reapplied.
                rb.useGravity = true;
                isGliding = false;
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
            isGliding = false;
        }
    }
}
