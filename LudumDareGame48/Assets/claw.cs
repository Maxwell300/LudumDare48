using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{

    public Animator animator;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            animator.SetBool("clawAttack", true);       
        }
        if(Input.GetButtonUp("Jump")){
            animator.SetBool("clawAttack", false);
        }    
    }
}
