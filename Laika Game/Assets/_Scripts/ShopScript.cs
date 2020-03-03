using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    public GameObject Laika;
    public ShopUI Shop;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Laika.transform.position, transform.position) < 2f) {
            
            //Display tooltip

            if(Input.GetButtonDown("Interact")) {
                Shop.Activate();
            }

        } 
    }
}
