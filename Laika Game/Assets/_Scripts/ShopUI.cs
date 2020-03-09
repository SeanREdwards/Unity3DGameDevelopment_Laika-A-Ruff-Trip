﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    private string Item = "";
    public GameObject minimap;
    public GameObject headNub, hatsListText;
    public Vector3 SpawnVector;
    private GameObject purchase;
    private int price;
    public PlayerHandler Player;
    public PlayerMovementController Movement;
    public GameObject magicHat, cowboyHat, pajamaHat, crown;
    public GameObject vikingHelmet, pillboxHat, policeCap, showerCap;
    public Animator ButtonsAnimator;
    [TextArea]
    Text t;
    int childInd;
    public GameObject Merchant, ShopCam, PlayerCam;

    private List<string> purchases;

    public void Start()
    {
        childInd = 0;
        purchases = new List<string>();
        t = hatsListText.GetComponent<Text>();

    }

    public void Activate() {
        gameObject.SetActive(true);
        minimap.SetActive(false);
        ButtonsAnimator.SetTrigger("Open");

        ShopCam.SetActive(true);
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
        headNub.GetComponent<ScrollHats>().ogText = t.text;
        //Exit();
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

                break;

            case "Pajama Hat":
                if (Player.GetPickupCount() >= price && !pajamaHat.GetComponent<IsBought>().isBought)
                {
                    pajamaHat.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(pajamaHat);

                    ActivateHat(Item);
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
                break;

            case "Viking Helmet":
                if (Player.GetPickupCount() >= price && !vikingHelmet.GetComponent<IsBought>().isBought)
                {
                    vikingHelmet.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(vikingHelmet);

                    ActivateHat(Item);
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
                break;
            case "Shower Cap":
                if (Player.GetPickupCount() >= price && !showerCap.GetComponent<IsBought>().isBought)
                {
                    showerCap.GetComponent<IsBought>().isBought = true;
                    t.text = t.text + "\n" + Item;
                    SetChildIndex(showerCap);

                    ActivateHat(Item);
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