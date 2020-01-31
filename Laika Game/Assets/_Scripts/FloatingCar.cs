using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCar : MonoBehaviour
{

    public float speed;
    public float turnSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        float rotation = moveHorizontal * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
