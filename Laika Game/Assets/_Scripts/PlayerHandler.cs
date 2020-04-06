using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    public GameHandler Game;
    private int count;
    public Text countText;


    void Start() {
        Game.LoadPlayer();
        SetCountText();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Bones x" + count.ToString();
    }

    public int GetPickupCount() {
        return count;
    }

    public void Spend(int n) {
        count -= n;
        SetCountText();
    }

    public void SetPickupCount(int n) {
        count = n;
        SetCountText();
    }

    public int GetScene() {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void SetScene(int n) {
        //DontDestroyOnLoad(this.transform.parent.gameObject);
        SceneManager.LoadScene(n);
    }

    public void Save() {
        Game.Save();
    }
}
