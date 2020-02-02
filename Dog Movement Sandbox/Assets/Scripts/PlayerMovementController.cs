using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public float move_speed;
	public float rotate_speed;

    public float jump_power;
    public Vector3 jump_vector;

    private Rigidbody rb;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump_power = 4.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move_vertical = Input.GetAxis("Vertical");
        float move_horizontal = Input.GetAxis ("Horizontal");

        Vector3 movement = new Vector3(0.0f, 0.0f, move_vertical);
        transform.Rotate(0, move_horizontal * rotate_speed * Time.deltaTime, 0);

        if(move_vertical < 0)
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
        if (isGrounded && Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }
}
