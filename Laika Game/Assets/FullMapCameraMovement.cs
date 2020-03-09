using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMapCameraMovement : MonoBehaviour
{
    Vector3 pos;
    float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            pos = Input.mousePosition;

            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed * -1, 0f, -1 * Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }


    }
}
