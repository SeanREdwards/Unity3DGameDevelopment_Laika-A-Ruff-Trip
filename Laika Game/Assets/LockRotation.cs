using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    Quaternion rotation;
    GameObject Laika;
    float originalY;

    // Start is called before the first frame update
    void Start()
    {
        Laika = GameObject.Find("Player");
        rotation = transform.rotation;
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = new Vector3(Laika.transform.position.x, originalY, Laika.transform.position.z);

    }
}
