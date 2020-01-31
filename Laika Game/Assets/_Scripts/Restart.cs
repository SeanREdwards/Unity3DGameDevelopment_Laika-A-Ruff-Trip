using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject prefab;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Laika")
        {
            SceneManager.LoadScene(3);
        }

        if(other.gameObject.tag == "Pickup")
        {
            Instantiate(other.gameObject, new Vector3(-1.5f, 0.5f, 14.16f), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
