using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    bool oneTrigger = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("MotusMan_v50");
        Animator playerAnimator = player.GetComponent<Animator>();
        Vector3 playerPos = player.transform.position;

        GameObject zombie = GameObject.Find("Zombie1");
        Animator zombieAnimator = zombie.GetComponent<Animator>();
        if (oneTrigger)
        {
            Vector3 targetDir = player.transform.position - transform.position;
            Vector3 rt = Vector3.RotateTowards(transform.forward, targetDir, 0.1f, 0.0f);
            transform.rotation = Quaternion.LookRotation(rt);
        }

        float dist = Vector3.Distance(transform.position, playerPos);
        print(dist);
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Swing Sword") && oneTrigger && dist < 2.0f)
        {
            zombieAnimator.SetTrigger("Death");
            oneTrigger = false;
        }
    }
}
