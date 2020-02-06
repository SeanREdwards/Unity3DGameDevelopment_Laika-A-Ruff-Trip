using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    public PlayerHandler Player;
    private string pathName;
    
    void Start()
    {
        pathName = Application.dataPath + "/save.txt";
    }

    private void Awake() {
        SaveObject saveObject = new SaveObject {
            pickups = 5,
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        Debug.Log(loadedSaveObject.pickups);
    }

    public void Save() {
        int pickups = Player.GetPickupCount();
        int scene = Player.GetScene();

        SaveObject saveObject = new SaveObject {
            pickups = pickups,
            scene = scene
        };

        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(pathName, json);

        Debug.Log("Saved!");
    }

    public void LoadScene() {
        if(File.Exists(pathName)) {
            string saveString = File.ReadAllText(pathName);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            
            Player.SetScene(saveObject.scene);
        }
    }

    public void LoadPlayer() {
        if (File.Exists(pathName)) {
            string saveString = File.ReadAllText(pathName);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            Player.SetPickupCount(saveObject.pickups);
        } else {
            Player.SetPickupCount(0);
        }
        
    }

    private class SaveObject {
        public int pickups;
        public int scene;
    }

}
