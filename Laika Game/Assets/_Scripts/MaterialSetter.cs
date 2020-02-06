using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSetter : MonoBehaviour
{
    private Material dogSkin;
    public GameObject materialPicker;
    public Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string s = "DogMaterial" + StaticVariableHolder.Material;
        string path = s;

        switch (StaticVariableHolder.Material)
        {

            case 0:
                dogSkin = materialPicker.GetComponent<MaterialHolder>().skin1;
                break;

            case 1:
                dogSkin = materialPicker.GetComponent<MaterialHolder>().skin2;
                break;

            case 2:
                dogSkin = materialPicker.GetComponent<MaterialHolder>().skin3;
                break;

            case 3:
                dogSkin = materialPicker.GetComponent<MaterialHolder>().skin4;
                break;

        }
        mats = transform.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
        mats[0] = dogSkin;
        transform.gameObject.GetComponent<SkinnedMeshRenderer>().materials = mats;
    }
}
