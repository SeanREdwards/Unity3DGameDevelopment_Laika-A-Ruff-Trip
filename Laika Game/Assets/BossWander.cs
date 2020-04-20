using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossWander : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public GameObject cannonBall;
    public float force = 0f;
    public Transform ProjectileAnchor1;
    public Transform ProjectileAnchor2;
    public Transform ProjectileAnchor3;
    private GameObject Laika;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        Laika = GameObject.Find("Player/Laika");
        player = GameObject.Find("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            if (timer >= wanderTimer * 1.5f)
            {
                ProjectileAnchor1.transform.rotation = Quaternion.Slerp(ProjectileAnchor1.transform.rotation, Quaternion.LookRotation(player.transform.position - ProjectileAnchor1.transform.position), 0.09f);
                ProjectileAnchor2.transform.rotation = Quaternion.Slerp(ProjectileAnchor2.transform.rotation, Quaternion.LookRotation(player.transform.position - ProjectileAnchor2.transform.position), 0.09f);
                ProjectileAnchor3.transform.rotation = Quaternion.Slerp(ProjectileAnchor3.transform.rotation, Quaternion.LookRotation(player.transform.position - ProjectileAnchor3.transform.position), 0.09f);

                GameObject projectile1 = (GameObject)Instantiate(cannonBall, ProjectileAnchor1.position, ProjectileAnchor1.rotation);
                projectile1.GetComponent<Rigidbody>().AddForce(projectile1.transform.forward * force);
                GameObject projectile2 = (GameObject)Instantiate(cannonBall, ProjectileAnchor2.position, ProjectileAnchor2.rotation);
                projectile2.GetComponent<Rigidbody>().AddForce(projectile2.transform.forward * force);
                GameObject projectile3 = (GameObject)Instantiate(cannonBall, ProjectileAnchor3.position, ProjectileAnchor3.rotation);
                projectile3.GetComponent<Rigidbody>().AddForce(projectile3.transform.forward * force);
                timer = 0;
            }
        }       
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}