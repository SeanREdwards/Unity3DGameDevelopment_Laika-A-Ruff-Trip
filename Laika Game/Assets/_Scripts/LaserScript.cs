﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    LineRenderer laserLine;
    CapsuleCollider capsule;
    float endX, startX, endY, startY, endZ, startZ;
    public bool capAdjust;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.startWidth = 0.1f;
        laserLine.endWidth = 0.1f;
        /*
        capsule = gameObject.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        capsule.radius = 0.05f;
        capsule.center = Vector3.zero;
        capsule.direction = 2;
        */
        capsule = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        endX = endPoint.transform.parent.transform.position.x-1;
        startX = startPoint.transform.parent.transform.position.x-1;
        /*
        endY = endPoint.transform.parent.transform.position.y - 1;
        startY = startPoint.transform.parent.transform.position.y - 1;

        endZ = endPoint.transform.parent.transform.position.z - 1;
        startZ = startPoint.transform.parent.transform.position.z - 1;
        */

        laserLine.SetPosition(0, startPoint.transform.position);
        laserLine.SetPosition(1, endPoint.transform.position);
        if (capAdjust)
        {
            capsule.height = (endPoint.transform.position - startPoint.transform.position).magnitude;
            float x = startX + (endX - startX) / 2;
            /*
            float y = startY + (endY - startY) / 2;
            float z = startZ + (endZ - startZ) / 2;
            */
            //x = x / 2;


            capsule.center = new Vector3(x, capsule.center.y, capsule.center.z);
        }
        /*
        capsule.transform.position = startPoint.transform.position + (endPoint.transform.position - startPoint.transform.position) / 2;
        capsule.transform.LookAt(startPoint.transform.position);
        capsule.height = (endPoint.transform.position - startPoint.transform.position).magnitude;
        */
    }
}
