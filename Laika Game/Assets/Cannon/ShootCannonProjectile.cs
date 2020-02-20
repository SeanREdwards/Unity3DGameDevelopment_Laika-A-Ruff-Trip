using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannonProjectile : MonoBehaviour
{
    public GameObject cannonBall;
    public float force = 0f;
    AudioSource audS;
    // Start is called before the first frame update
    void Start()
    {
        audS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            GameObject projectile = (GameObject)Instantiate(cannonBall, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * force);
            audS.Play();
        }
    }
}
