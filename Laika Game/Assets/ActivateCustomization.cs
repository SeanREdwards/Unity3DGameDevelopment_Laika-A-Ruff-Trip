using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class ActivateCustomization : MonoBehaviour
{
    public GameObject custom, player, customizationCam, minimap;
    public GameObject headNub;
    public Text text;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetLayerRecursively(GameObject obj, int layer)
    {
        if (obj.layer != 8)
        {
            obj.layer = layer;
        }
        foreach(Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);
        }
    }

    void SetCurrentHat()
    {
        int s = -1;
        for(int k = 0; k < headNub.transform.childCount; k++)
        {
            if (headNub.transform.GetChild(k).gameObject.activeSelf)
            {
                s = k;
                break;
            }
        }

        if(s != -1)
        {
            string str = headNub.transform.GetChild(s).gameObject.name;
            text.text = text.text.Replace(str, "<b><color=#ffa500ff><size=25>" + str + "</size></color></b>");
        }
    }

    public void TurnOnCustomization()
    {
        SetCurrentHat();
        
        custom.SetActive(true);
        customizationCam.SetActive(true);
        this.transform.GetChild(0).gameObject.SetActive(false);
        SetLayerRecursively(player, 9);
        player.layer = 9;
        player.GetComponent<PlayerMovementController>().enabled = false;
        player.GetComponentInChildren<CinemachineFreeLook>().enabled = false;
        Time.timeScale = 1f;
    }

    public void BackToPause()
    {
        custom.SetActive(false);
        customizationCam.SetActive(false);

        this.transform.GetChild(0).gameObject.SetActive(true);
        player.GetComponentInChildren<CinemachineFreeLook>().enabled = true;
        Time.timeScale = 0f;
        player.layer = 0;
        SetLayerRecursively(player, 0);
        player.GetComponent<PlayerMovementController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
