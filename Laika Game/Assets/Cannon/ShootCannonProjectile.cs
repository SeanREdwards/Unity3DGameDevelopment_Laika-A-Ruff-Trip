using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootCannonProjectile : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject shootText;
    public GameObject turretCam;
    GameObject laikaCam;
    public float force = 0f;
    AudioSource audS;
    bool canPress = false;
    bool isCharged = false;
    int shots = 0;
    // Start is called before the first frame update
    void Start()
    {
        audS = this.GetComponent<AudioSource>();
        laikaCam = GameObject.Find("Player").transform.GetChild(6).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharged && canPress && Input.GetKeyDown("f"))
        {
            shots = shots - 1;
            if (shots == 0)
            {
                isCharged = false;
                transform.GetChild(0).gameObject.SetActive(false);

            }

            GameObject projectile = (GameObject)Instantiate(cannonBall, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * force);
            audS.Play();
        }




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            canPress = true;
            laikaCam.SetActive(false);
            turretCam.SetActive(true);
            rotate r = transform.parent.parent.parent.parent.GetComponent<rotate>();
            RotateOpposite ro= transform.parent.parent.parent.parent.GetComponent<RotateOpposite>();

            if(r != null)
            {
                r.rotationsPerMinute = 5f;
            } else if(ro != null)
            {
                ro.rotationsPerMinute = 5f;
            }

            if (isCharged)
            {
                shootText.SetActive(true);
            }
        }else if(isCharged == false && other.gameObject.name == "Battery")
        {
            isCharged = true;
            shots = 3;
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            canPress = false;
            laikaCam.SetActive(true);
            turretCam.SetActive(false);
            shootText.SetActive(false);

            rotate r = transform.parent.parent.parent.parent.GetComponent<rotate>();
            RotateOpposite ro = transform.parent.parent.parent.parent.GetComponent<RotateOpposite>();

            if (r != null)
            {
                r.rotationsPerMinute = 1f;
            }
            else if (ro != null)
            {
                ro.rotationsPerMinute = 1f;
            }

        }
    }
}
