using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{

    private string Item = "";
    public Vector3 SpawnVector;
    private GameObject purchase;
    private int price;
    public PlayerHandler Player;

    public void Activate() {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
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
        Time.timeScale = 1f;
    }
}
