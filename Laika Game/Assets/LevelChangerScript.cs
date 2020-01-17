using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangerScript : MonoBehaviour
{

    public Animator animator;

    public void fade()
    {
        animator.SetTrigger("FadeOut");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
