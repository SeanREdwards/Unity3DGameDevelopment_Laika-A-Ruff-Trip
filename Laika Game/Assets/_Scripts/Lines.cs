using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    public GameObject lineOrigin;
    public GameObject pickup;
    private Vector3 originLocation;
    private Vector3 pickupLocation;
    private GameObject pickupHold;
    LineRenderer lineRenderer;
    LineRenderer lineRendererDown;
    public GameObject line;
    public Vector3[] points;
    public Shader standard;
    public Shader outlined;
    public GameObject tooltip;
    public GameObject lineDown;
    public GameObject pause;
    public Vector3[] pointsLineDown;
    GameObject player;
    private GameObject playerBall;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.gameObject;
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;

        lineRendererDown = lineDown.GetComponent<LineRenderer>();
        lineRendererDown.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerObjectMovement>().ball != null)
        {
            if (player.GetComponent<PlayerObjectMovement>().canHold)
            {
                if (!pause.GetComponent<PauseScript>().paused)
                {
                    tooltip.SetActive(true);
                }
            }
            //Player to pickup
            pickup = player.GetComponent<PlayerObjectMovement>().ball;
            if (pickup != pickupHold && pickupHold != null)
            {
                pickupHold.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");
            }

            pickupHold = pickup;
            originLocation = lineOrigin.transform.position;
            pickupLocation = pickup.transform.position;
            points[0] = originLocation;
            points[1] = pickupLocation;
            lineRenderer.SetPositions(points);
            lineRenderer.enabled = true;

            //Pickup to ground
            pointsLineDown[0] = pickupLocation;
            Vector3 downPos = pickupLocation - new Vector3(0f, 30f, 0f);
            pointsLineDown[1] = downPos;
            lineRendererDown.SetPositions(pointsLineDown);
            lineRendererDown.enabled = true;
            
            pickup.gameObject.GetComponent<MeshRenderer>().materials[0].shader = outlined;
            
        } else
        {
            tooltip.SetActive(false);
            lineRenderer.enabled = false;
            lineRendererDown.enabled = false;
            if (pickup != null)
            {
                pickup.gameObject.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");
            }
        }
    }
}
