using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            animator.SetBool("clawAttack", true); 
            Debug.Log("AWDHUAWNFUIWAFNIO");      
        }
  
    }
}
