using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileScript : MonoBehaviour
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
        print(collision.gameObject);
            Instantiate(Resources.Load("ProjectileExplosion(Purple)"), gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        
    }
}
