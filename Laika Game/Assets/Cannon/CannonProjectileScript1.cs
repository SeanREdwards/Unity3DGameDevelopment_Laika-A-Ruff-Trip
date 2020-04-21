using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileScript1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject != GameObject.Find("Polyart_Golem"))
        {
            Instantiate(Resources.Load("ProjectileExplosion(Brown)"), gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
