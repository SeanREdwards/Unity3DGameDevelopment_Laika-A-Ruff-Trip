/*
DogAnimationController.cs
Script that provides animation controller with information to change character object states.

@Author Sean Edwards.
@Version 20200120
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimationController: MonoBehaviour
{
    Animator animator;

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


        //If non-zero and no speed animation should turn while walking in place.
        if (rotation != 0)
        {
            animator.SetBool("Rotating", true);
        }
        else
        {
            animator.SetBool("Rotating", false);
        }
        
        //Reset jumping trigger.
        animator.ResetTrigger("Jump");
        animator.ResetTrigger("Bite");
        animator.ResetTrigger("Bark");


        //Activate jumping animation.
        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Jump");
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
