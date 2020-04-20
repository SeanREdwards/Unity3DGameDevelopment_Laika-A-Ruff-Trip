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
    Color alphaColor;
    float timeToFade = 1f;
    bool canFade = false;
    AudioSource audS;
    public GameObject victory, bossDefeat;
    public GameObject bossMusic;
    private void Start()
    {
        healthBar.value = 100;
        health = 25;
        anim = GetComponent<Animator>();
        audS = this.GetComponent<AudioSource>();
        //alphaColor = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color;
        //alphaColor.a = 0;
    }

    private void Update()
    {

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
                BossDefeat();
                Invoke("VictorySound", 0.5f);
            }
        }
    }

    void BossDefeat()
    {
        canFade = true;
    }


    void VictorySound()
    {
        victory.SetActive(true);
        bossMusic.SetActive(false);
        GetComponent<BossWander>().enabled = false;
        bossDefeat.SetActive(true);
    }
    

}
