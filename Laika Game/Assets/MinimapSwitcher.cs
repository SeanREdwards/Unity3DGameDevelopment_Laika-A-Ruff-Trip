using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapSwitcher : MonoBehaviour
{

    public Camera minimapCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MinimapSwitchToDefault()
    {
        minimapCam.cullingMask |= 1 << LayerMask.NameToLayer("Default");
        minimapCam.cullingMask &= ~(1 << LayerMask.NameToLayer("Minimap"));
    }

    public void MinimapSwitchToMinimap()
    {
        minimapCam.cullingMask &= ~(1 << LayerMask.NameToLayer("Default"));
        minimapCam.cullingMask |= 1 << LayerMask.NameToLayer("Minimap");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
