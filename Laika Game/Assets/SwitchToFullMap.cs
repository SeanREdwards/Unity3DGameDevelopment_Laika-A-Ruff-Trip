using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchToFullMap : MonoBehaviour
{
    public GameObject fullmapCamera;
    public GameObject fullMap, miniMap;
    public GameObject player;

    public void SwitchFullScreen()
    {
        fullmapCamera.GetComponent<FullMapCameraMovement>().enabled = true;
        fullmapCamera.GetComponent<LockRotation>().enabled = false;

        fullMap.SetActive(true);
        player.GetComponentInChildren<CinemachineFreeLook>().enabled = false;
        miniMap.SetActive(false);
    }

    public void SwitchMinimap()
    {
        fullmapCamera.GetComponent<FullMapCameraMovement>().enabled = false;
        fullmapCamera.GetComponent<LockRotation>().enabled = true;

        fullMap.SetActive(false);
        player.GetComponentInChildren<CinemachineFreeLook>().enabled = true;

        miniMap.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
