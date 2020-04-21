using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaChildOfPlatform : MonoBehaviour
{
    GameObject Laika, player;
    // Start is called before the first frame update
    void Start()
    {
        Laika = GameObject.Find("Player/Laika");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.gameObject == Laika && Input.GetKeyDown(KeyCode.Backspace))
        {
            DontDestroyOnLoad(Laika.transform.parent.gameObject);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Laika)
        {
            print("Enter");
            Laika.transform.parent.parent = transform;
            player.GetComponent<ResetLevel>().enabled = false;
            player.transform.GetChild(5).GetChild(1).GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Laika)
        {
            Laika.transform.parent.parent = null;
            DontDestroyOnLoad(Laika.transform.parent.gameObject);
            player.GetComponent<ResetLevel>().enabled = true;
            player.transform.GetChild(5).GetChild(1).GetChild(0).gameObject.SetActive(true);

        }
    }

}
