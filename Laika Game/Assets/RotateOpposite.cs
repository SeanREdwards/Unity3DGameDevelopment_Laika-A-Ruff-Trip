using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOpposite : MonoBehaviour
{
    public float rotationsPerMinute;

    // Start is called before the first frame update
    void Start()
    {
        rotationsPerMinute = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }


}
