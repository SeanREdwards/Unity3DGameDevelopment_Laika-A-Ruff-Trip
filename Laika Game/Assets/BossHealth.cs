using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [HideInInspector]
    public int health;
    public Slider healthBar;
    Animator anim;
    AudioSource audS;
    public GameObject victory;
    public GameObject bossMusic;
    private void Start()
    {
        healthBar.value = 100;
        health = 100;
        anim = this.transform.GetChild(0).GetComponent<Animator>();
        audS = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cannon_Projectile")
        {
            health = health - 25;
            audS.Play();
            healthBar.value = health;
            if (health != 0)
            {
                anim.SetTrigger("Damage");
            } else { 
                            anim.SetTrigger("Death");
                this.GetComponent<BossBackAndForth>().enabled = false;
                Invoke("VictorySound", 0.5f);
            }
        }
    }

    void VictorySound()
    {
        victory.SetActive(true);
        bossMusic.SetActive(false);
    }
    

}
