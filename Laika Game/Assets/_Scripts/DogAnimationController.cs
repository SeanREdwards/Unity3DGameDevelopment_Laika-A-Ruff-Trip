/*
DogAnimationController.cs
Script that provides animation controller with information to change character object states.
@Author Sean Edwards.
@Version 20200120
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimationController : MonoBehaviour
{
    Animator animator;
    private bool canJump;
    private bool isSprinting;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        float speed = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", speed);
        animator.SetBool("Sprinting", gameObject.GetComponentInParent<PlayerMovementController>().isSprinting);
        //Reset jumping trigger.
        //animator.ResetTrigger("Jump");
        animator.ResetTrigger("Bite");
        animator.ResetTrigger("Bark");

        //Check is grounded from movement script. If not grounded set trigger.
        if (!gameObject.GetComponentInParent<PlayerMovementController>().isGrounded)
        {
            animator.SetBool("Grounded", false);
            if (canJump)
            {
                canJump = false;
                animator.SetTrigger("Jump");
            }
            else
            {
                animator.ResetTrigger("Jump");
            }
        }
        else
        {
            animator.SetBool("Grounded", true);
            canJump = true;

            //If non-zero and no speed animation should turn while walking in place.
            if (rotation != 0)
            {
                animator.SetBool("Rotating", true);
            }
            else
            {
                animator.SetBool("Rotating", false);
            }
        }

        if (Input.GetKeyDown("f"))
        {
            animator.SetTrigger("Bite");
        }

        if (Input.GetKeyDown("g"))
        {
            animator.SetTrigger("Bark");
        }
    }
}