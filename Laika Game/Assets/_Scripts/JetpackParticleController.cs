using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackParticleController : MonoBehaviour
{

    public ParticleSystem ps;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(ps);
    }

    // Update is called once per frame
    void Update()
    {
        ps.enableEmission = player.GetComponent<PlayerMovementController>().isGliding;
    }
}
