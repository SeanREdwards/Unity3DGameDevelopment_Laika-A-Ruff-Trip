using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotationWithOffset : MonoBehaviour
{

    public GameObject Laika;
    Quaternion rotation;
    float originalY;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = rotation;
        offset = Laika.transform.position - transform.position;
        print(offset);
        //transform.position = new Vector3(Laika.transform.position.x, originalY, Laika.transform.position.z);
    }
}
