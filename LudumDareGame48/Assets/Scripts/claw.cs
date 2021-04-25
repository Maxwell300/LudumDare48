using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{

    public Animator animator;
    public float deathdelay = 10f;
    bool dead = false;
    Character character;

    void Update()
    {
        GlobalVariables.Timer(ref dead, ref deathdelay);

        if(!dead && deathdelay <= 0){
            character.resetLevel();
        }
    }

    void OnTriggerEnter2D (Collider2D other) {      // Trigger animation and delay for death
        character = other.GetComponent<Character>();
        if (character != null) {
            dead = true;
            animator.SetBool("clawAttack", true);
        }
    }
}
