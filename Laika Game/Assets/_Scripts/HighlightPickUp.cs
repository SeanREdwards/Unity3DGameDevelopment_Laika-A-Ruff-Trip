using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPickUp : MonoBehaviour
{
    public Material highlight;


    // Start is called before the first frame update
    void Start()
    {
        highlight.SetFloat("_Outline",0.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
