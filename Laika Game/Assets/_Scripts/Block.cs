using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public GameObject block;
    public Animator BlockAnimator;
    private bool moved;

    // Start is called before the first frame update
    void Start()
    {
        BlockAnimator = block.GetComponent<Animator>();
        moved = false;
    }

    public bool IsMoved() {
        return moved;
    }
 
    public void Move() {
        moved = true;
        BlockAnimator.SetTrigger("Move");
    }

    public void Return() {
        moved = false;
        BlockAnimator.SetTrigger("Return");
    }
}
