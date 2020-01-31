using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SoundOff()
    {
        print("here");
        sound.gameObject.SetActive(false);
        Destroy(this.transform.gameObject);

    }

    public void SetAllCollidersStatus(bool active)
    {
        foreach (Collider c in this.GetComponents<Collider>())
        {
            c.enabled = active;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            sound.gameObject.SetActive(true);
            Invoke("SoundOff", 1.5f);
            this.GetComponent<MeshRenderer>().enabled = false;
            SetAllCollidersStatus(false);
        }
    }
}
