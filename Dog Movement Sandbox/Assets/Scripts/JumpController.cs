/*
JumpController.cs
Script to allow for jumping and falling of player body as well as adjusting when player is within appropraite y-axis bounds.
@Author Sean Edwards.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController: MonoBehaviour
{	
	public float falling_speed;
	public float delta_t;
	public float delta_f;
	public float gravity;
	
    // Start is called before the first frame update
    void Start()
    {
		/*Set variable values.*/
        falling_speed = 0.0f;
	    delta_t = 0.05f;
		delta_f = 8.0f;
		gravity = 9.8f;
    }

    // Update is called once per frame
    void Update()
    {

		if(transform.position.y <= 5.0f){
			falling_speed = 0.0f;
			if (Input.GetKeyDown("space")){
				falling_speed += delta_f; 
			}
		} else{
				falling_speed = falling_speed - (gravity * delta_t);
		}
		
		Vector3 jump_vector = new Vector3(0.0f, falling_speed * delta_t, 0.0f);
		transform.position += jump_vector;
		
		if(transform.position.y < 5.0f){
			jump_vector.x = transform.position.x;
			jump_vector.y = 5.0f;
			jump_vector.z = transform.position.z;
			transform.position = jump_vector;
		}
		
    }
}
