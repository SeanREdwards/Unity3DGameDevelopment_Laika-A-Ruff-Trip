using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    private Material dogSkin;
    public Material[] mats; 
    // Start is called before the first frame update
    void Start()
    {
        string s = "DogMaterial" + StaticVariableHolder.Material;
        string path = "Materials/" + s;
        print(path);
        dogSkin = Resources.Load<Material>(path);
        print(dogSkin);
        mats = transform.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        mats[0] = dogSkin;
        transform.gameObject.GetComponent<SkinnedMeshRenderer>().materials = mats;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
