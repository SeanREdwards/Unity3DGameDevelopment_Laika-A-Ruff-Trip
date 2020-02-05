using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    public GameObject lineOrigin;
    public GameObject pickup;
    private Vector3 originLocation;
    private Vector3 pickupLocation;
    LineRenderer lineRenderer;
    public GameObject line;
    public Vector3[] points;
    public GameObject player;
    public Shader highlight;
    public Shader normal;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerObjectMovement>().ball != null)
        {
            pickup = player.GetComponent<PlayerObjectMovement>().ball;
            originLocation = lineOrigin.transform.position;
            pickupLocation = pickup.transform.position;
            points[0] = originLocation;
            points[1] = pickupLocation;
            lineRenderer.SetPositions(points);
            lineRenderer.enabled = true;
//            player.GetComponent<PlayerObjectMovement>().ball.gameObject.GetComponent<Renderer>().material.shader = 
        } else
        {
            lineRenderer.enabled = false;
        }
    }
}
