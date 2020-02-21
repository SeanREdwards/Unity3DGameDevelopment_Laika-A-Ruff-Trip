using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtTheDog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Laika"))
        {
            other.gameObject.transform.parent.transform.position = new Vector3(6.9f, 0.25f, 40f);
            //Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
