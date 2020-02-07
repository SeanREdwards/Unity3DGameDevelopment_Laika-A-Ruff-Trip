using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingToObject : MonoBehaviour
{
    public static GameObject selectedObject;
    public GameObject internalObject;
    public RaycastHit theObject;
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theObject))
        {
            selectedObject = theObject.transform.gameObject;
            internalObject = theObject.transform.gameObject;
        }
    }
}
