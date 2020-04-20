using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeated : MonoBehaviour
{
    AudioSource[] allAudio;
    public GameObject overviewCam, boss;
    public GameObject mechanic;
    public GameObject group2, group3;
    public GameObject mesh1;
    public GameObject victoryMusic;
    GameObject laika, laikaCam;
    Color alphaColor;
    float timeToFade = 1f;
    bool canFade = false;
    // Start is called before the first frame update
    private void Awake()
    {
        allAudio = FindObjectsOfType<AudioSource>();
    }

    void Start()
    {
        laika = GameObject.Find("Player");
        
        laikaCam = laika.transform.GetChild(6).gameObject;
        Invoke("Overview", 1.5f);
    }

    void Overview()
    {
        group2.GetComponent<rotate>().rotationsPerMinute = 1f;
        group3.GetComponent<RotateOpposite>().rotationsPerMinute = 1f;
        StopAllAudio();
        overviewCam.SetActive(true);
        laikaCam.SetActive(false);
        Invoke("BossFade", 1f);
    }

    void StopAllAudio()
    {
        for(int i =0; i < allAudio.Length; i++)
        {
            allAudio[i].Stop();
        }
    }

    void BossFade()
    {
        canFade = true;
        Invoke("DespawnBoss", 2f);
    }

    void DespawnBoss()
    {
        boss.SetActive(false);
        Invoke("SpawnMechanic", 1f);
    }

    void SpawnMechanic()
    {
        victoryMusic.SetActive(true);
        mesh1.transform.localPosition = new Vector3(0, -0.03f, 0);
        mechanic.SetActive(true);
        Invoke("PlayerControl", 1f);
    }

    void PlayerControl()
    {
        laikaCam.SetActive(true);
        overviewCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canFade)
        {
            boss.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(boss.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
        }
    }
}
