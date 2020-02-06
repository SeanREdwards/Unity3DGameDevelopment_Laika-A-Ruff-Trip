using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpScript : MonoBehaviour
{

    public PlayerHandler Player;
    public GameObject Door;
    public GameObject Text;
    public float AlertDistance;
    private float d;
    public int targetScene;

    // Start is called before the first frame update
    void Start()
    {
        d = Vector3.Distance(Player.transform.position, Door.transform.position);
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        d = Vector3.Distance(Player.transform.position, Door.transform.position);
        if (d < AlertDistance) {
            
            Text.SetActive(true);
            if (Input.GetButtonDown("Interact")) {
                Player.Save();
                SceneManager.LoadScene(targetScene);
            }
           

        }
        else {
            Text.SetActive(false);
        }
    }
}
