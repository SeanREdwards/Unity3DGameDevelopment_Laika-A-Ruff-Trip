using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShopUI : MonoBehaviour
{

    private string Item = "";
    public Vector3 SpawnVector;
    private GameObject purchase;
    private int price;
    public PlayerHandler Player;
    public PlayerMovementController Movement;

    public Animator ButtonsAnimator;
    public GameObject Merchant, ShopCam, PlayerCam;

    public void Activate() {
        gameObject.SetActive(true);
        ButtonsAnimator.SetTrigger("Open");

        ShopCam.SetActive(true);
        PlayerCam.SetActive(false);
        
        ShopCam.GetComponent<CinemachineVirtualCamera>().LookAt = Merchant.transform;

        Movement.isPaused = true;

    }

    public void SelectItem(string selection) {
        Item = selection;
        Debug.Log(selection);
    }

    public void GetPrice(int n) {
        price = n;
    }

    public void Buy() {
        if (Player.GetPickupCount() >= price) {
            purchase = GameObject.Find(Item);
            purchase.transform.position = SpawnVector;
            Player.Spend(price);
            
            Exit();
        }
    }

    public void Exit() {
        gameObject.SetActive(false);
        ButtonsAnimator.SetTrigger("Close");

        Movement.isPaused = false;

        PlayerCam.SetActive(true);
        ShopCam.SetActive(false);

        ShopCam.GetComponent<CinemachineVirtualCamera>().LookAt = null;


    }
}
