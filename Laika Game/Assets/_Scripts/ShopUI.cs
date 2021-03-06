﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    private string Item = "";
    public GameObject minimap;
    GameObject headNub, hatsListText;
    public Vector3 SpawnVector;
    private GameObject purchase;
    private int price;
    [HideInInspector]
    public PlayerHandler Player;
    [HideInInspector]
    public PlayerMovementController Movement;
    GameObject magicHat, cowboyHat, pajamaHat, crown;
    GameObject vikingHelmet, pillboxHat, policeCap, showerCap;
    public Animator ButtonsAnimator;
    [TextArea]
    Text t;
    int childInd;
    public GameObject Merchant, ShopCam, PlayerCam;
    public AudioSource ads, fail;

    private List<string> purchases;

    public void Start()
    {
        GameObject Laika = GameObject.Find("Player");
        PlayerCam = Laika.transform.GetChild(6).gameObject;
        headNub = GameObject.Find("Bip01 HeadNub");
        pajamaHat = headNub.transform.GetChild(0).gameObject;
        magicHat = headNub.transform.GetChild(1).gameObject;
        cowboyHat = headNub.transform.GetChild(2).gameObject;
        crown = headNub.transform.GetChild(3).gameObject;
        vikingHelmet = headNub.transform.GetChild(4).gameObject;
        policeCap = headNub.transform.GetChild(5).gameObject;
        showerCap = headNub.transform.GetChild(6).gameObject;
        pillboxHat = headNub.transform.GetChild(7).gameObject;
        Player = Laika.GetComponentInChildren<PlayerHandler>();
        Movement = Laika.GetComponent<PlayerMovementController>();
        childInd = 0;
        purchases = new List<string>();
        hatsListText = GameObject.Find("Pause").transform.GetChild(1).transform.GetChild(4).gameObject;
        t = hatsListText.GetComponent<Text>();

    }

    public void Activate() {
        gameObject.SetActive(true);
        minimap.SetActive(false);
        ButtonsAnimator.SetTrigger("Open");

        ShopCam.SetActive(true);
        PlayerCam = GameObject.Find("Player").transform.GetChild(6).gameObject;
        PlayerCam.SetActive(false);
        
        ShopCam.GetComponent<CinemachineVirtualCamera>().LookAt = Merchant.transform;

        Movement.isPaused = true;

    }

    public void SelectItem(string selection) {
        Item = selection;
        //Debug.Log(selection);
    }

    public void GetPrice(int n) {
        price = n;
    }

    void ActivateHat(string name)
    {
        foreach(Transform child in headNub.transform)
        {
            if(!(child.name == name))
            {
                child.gameObject.SetActive(false);
            } else
            {
                child.gameObject.SetActive(true);
            }
        }
        Player.Spend(price);
        ads.Play();
        /*
        headNub.GetComponent<ScrollHats>().ogText = headNub.GetComponent<ScrollHats>().ogText.Replace("<b><color=#ffa500ff><size=25>", "");
        headNub.GetComponent<ScrollHats>().ogText = headNub.GetComponent<ScrollHats>().ogText.Replace("</size></color></b>", "");
        */
        headNub.GetComponent<ScrollHats>().ogText = t.text;
        //Exit();
    }

    void FailBuy()
    {
        fail.Play();
    }

    void SetChildIndex(GameObject obj)
    {
        obj.transform.SetSiblingIndex(childInd);
        childInd += 1;
    }

    public void Buy() {
        
        switch (Item)
        {
            case "Magician Hat":
                if (Player.GetPickupCount() >= price && !magicHat.GetComponent<IsBought>().isBought)
                {
                    magicHat.GetComponent<IsBought>().isBought = true;
                    SetChildIndex(magicHat);
                    t.text = t.text + "\n" + Item;
                    ActivateHat(Item);
                } else
                {
                    FailBuy();
                }


                break;

            case "Cowboy Hat":
                if (Player.GetPickupCount() >= price && !cowboyHat.GetComponent<IsBought>().isBought)
                {
                    cowboyHat.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(cowboyHat);
                    ActivateHat(Item);

                }
                else
                {
                    FailBuy();
                }

                break;

            case "Pajama Hat":
                if (Player.GetPickupCount() >= price && !pajamaHat.GetComponent<IsBought>().isBought)
                {
                    pajamaHat.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(pajamaHat);

                    ActivateHat(Item);
                }
                else
                {
                    FailBuy();
                }
                break;

            case "Crown":
                if(Player.GetPickupCount() >= price && !crown.GetComponent<IsBought>().isBought)
                {
                    crown.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(crown);

                    ActivateHat(Item);
                }
                else
                {
                    FailBuy();
                }
                break;

            case "Viking Helmet":
                if (Player.GetPickupCount() >= price && !vikingHelmet.GetComponent<IsBought>().isBought)
                {
                    vikingHelmet.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(vikingHelmet);

                    ActivateHat(Item);
                }
                else
                {
                    FailBuy();
                }
                break;
            case "Police Cap":
                if (Player.GetPickupCount() >= price && !policeCap.GetComponent<IsBought>().isBought)
                {
                    policeCap.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(policeCap);

                    ActivateHat(Item);
                }
                else
                {
                    FailBuy();
                }
                break;
            case "Shower Cap":
                if (Player.GetPickupCount() >= price && !showerCap.GetComponent<IsBought>().isBought)
                {
                    showerCap.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(showerCap);

                    ActivateHat(Item);
                }
                else
                {
                    FailBuy();
                }
                break;
            case "Pillbox Hat":
                if (Player.GetPickupCount() >= price && !pillboxHat.GetComponent<IsBought>().isBought)
                {
                    pillboxHat.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(pillboxHat);

                    ActivateHat(Item);
                }
                else
                {
                    FailBuy();
                }
                break;

            default:
                if (Player.GetPickupCount() >= price && !purchases.Contains(Item))
                {
                    purchases.Add(Item);
                    purchase = GameObject.Find(Item);
                    purchase.transform.position = SpawnVector;
                    Player.Spend(price);

                    Exit();
                }
                else
                {
                    FailBuy();
                }
                break;
        }

        /*
        if (Player.GetPickupCount() >= price && !purchases.Contains(Item))
            {
                purchases.Add(Item);
                purchase = GameObject.Find(Item);
                purchase.transform.position = SpawnVector;
                Player.Spend(price);

                Exit();
            }wd
        */
    }

    public void Exit() {
        gameObject.SetActive(false);
        ButtonsAnimator.SetTrigger("Close");
        minimap.SetActive(true);
        Movement.isPaused = false;

        PlayerCam.SetActive(true);
        ShopCam.SetActive(false);

        ShopCam.GetComponent<CinemachineVirtualCamera>().LookAt = null;


    }
}
